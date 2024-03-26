using Networking.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShahFileDissemination.Crypto
{
    public class ShahDissemination
    {
        public List<List<BigInteger>> M { get; set; }
        public SDParameters Params { get; set; }
        public int SecretId { get; set; }
        public ShahDissemination(SDParameters parameters)
        {
            Params = parameters;
            SecretId = (int)(SecurityUtils.NextBigInteger(1, 999));
        }
        public UnivariatePoly ComputeUniPoly(int ToNodeId)
        {
            UnivariatePoly poly = new UnivariatePoly(ToNodeId, SecretId);
            poly.coeffs = new BigInteger[Params.d];
            for(int i = 0; i < Params.d; i++)
            {
                for(int j = 0; j < Params.d; j++)
                {
                    poly.coeffs[i] += M[i][j] * BigInteger.Pow(ToNodeId, j);
                }
                poly.coeffs[i] = (poly.coeffs[i] % Params.p + Params.p) % Params.p;
            }
            return poly;
        }
        public void GenerateMatrix(BigInteger secret)
        {
            GenerateMatrix(new BigInteger[] { secret });
        }
        public void GenerateMatrix(BigInteger[] secrets)
        {
            if (secrets.Length != Params.d - Params.k + 1) throw new ArgumentException("Number of secrets must be equal to d-k + 1.");
            int maxSecretByteSize = PublicMemory.MaxSecretSize;
            for (int i = 0; i < secrets.Length; i++)
            {
                if ((secrets[i].ToByteArray().Length > maxSecretByteSize))
                    throw new ArgumentException("Secret is larger than prime");
            }
            M = new List<List<BigInteger>>(Params.d);
            for (int i = 0; i < Params.d; i++)
            {
                M.Add(new List<BigInteger>());
                for (int j = 0; j < Params.d; j++)
                {
                    M[i].Add(new BigInteger(0));
                }
            }
            List<(int, int)> skip = new List<(int, int)>();
            for (int i = 0; i < Params.d; i++)
            {
                for (int j = 0; j < Params.d; j++)
                {
                    if (!skip.Contains((j, i)) && (!((i >= Params.k) && (j >= Params.k))))
                    {
                        BigInteger r = SecurityUtils.NextBigInteger(1, Params.p - 1);
                        M[i][j] = r;
                        M[j][i] = r;
                        skip.Add((i, j));
                    }
                }
            }
            M[0][0] = secrets[0];
            for (int i = 1; i < secrets.Length; i++)
            {
                M[0][Params.k + i - 1] = secrets[i];
                M[Params.k + i - 1][0] = secrets[i];
            }

        }


    }
    public class UnivariatePoly {
        public UnivariatePoly(int d, UnivariatePolynomial poly)
        {
            this.d = d;
            this.OwnerNodeId = poly.OwnerNodeId;
            this.SecretId = poly.SecretId;
            coeffs = new BigInteger[poly.Coefficients.Count];
            for(int i = 0; i < poly.Coefficients.Count; i++)
            {
                coeffs[i] = BigInteger.Parse(poly.Coefficients[i], System.Globalization.NumberStyles.HexNumber);
            }
        }
        public UnivariatePoly(int OwnerNodeId, int SecretId)
        {
            this.d = DefaultParameters.dPropagation;
            this.OwnerNodeId = OwnerNodeId;
            this.SecretId = SecretId;
        }
        public int OwnerNodeId { get; set; }
        public int d { get; set; }
        public int SecretId { get; set; }
        public List<Scalar> Scalars = new List<Scalar>();
        public BigInteger[] coeffs { get; set; }
        public Scalar Eval(int ToNodeId)
        {
            if (coeffs.Length == 0) throw new Exception("No coefficients are available.");
            BigInteger p = DefaultParameters.Prime;
            BigInteger sum = 0;
            for (int i = 0; i < coeffs.Length; i++)
            {
                sum += coeffs[i] * BigInteger.Pow(ToNodeId, i);
            }
            return new Scalar((sum % p + p) % p, OwnerNodeId, (ToNodeId == 0) ? OwnerNodeId  : ToNodeId, SecretId );
        }
        public void AddScalar(Scalar scalar)
        {
            this.Scalars.Add(scalar);
        }
        public BigInteger[] ReconstructPoly()
        {
            BigInteger p = DefaultParameters.Prime;
            List<List<BigInteger>> brackets = new List<List<BigInteger>>();
            List<BigInteger> divisors = new List<BigInteger>();
            for (int j = 0; j < Scalars.Count; j++)
            {
                brackets.Add(new List<BigInteger>());
                divisors.Add(1);
                for (int m = 0; m < Scalars.Count; m++)
                {
                    if(m != j)
                    {
                        brackets[j].Add(-Scalars[m].FromNodeId);
                        divisors[j] *= (Scalars[j].FromNodeId - Scalars[m].FromNodeId);
                    }
                }
            }
            List<Bracket> expandBrackets = ExpandBrackets(brackets);
            BigInteger[] reconstPoly = new BigInteger[expandBrackets.Count];
            for (int i = 0; i < expandBrackets.Count; i++)
            {
                for(int j = 0; j < expandBrackets[i].Members.Count; j++)
                {
                    expandBrackets[i].Members[j].Value = expandBrackets[i].Members[j].Value * Scalars[i].Value;

                    //reconstPoly[expandBrackets[i].Members.Count - j -1 ] +=  expandBrackets[i].Members[j].Value / divisors[i];

                    BigInteger divisor = (divisors[i] + p) % p;
                    //reconstPoly[expandBrackets[i].Members.Count - j - 1] += expandBrackets[i].Members[j].Value * BigInteger.ModPow(divisor, p-2 ,p );
                    reconstPoly[expandBrackets[i].Members.Count - j - 1] +=  (expandBrackets[i].Members[j].Value * SecurityUtils.ModInversion(divisor, p)) % p;

                    reconstPoly[expandBrackets[i].Members.Count - j -1 ] = (reconstPoly[expandBrackets[i].Members.Count - j - 1] % p + p) % p;
                }
            }
            this.coeffs = reconstPoly;
            return reconstPoly;
        }

        private List<Bracket> ExpandBrackets(List<List<BigInteger>> bracketStructure)
        {
            List<Bracket> expandedBrackets = new List<Bracket>();
            for (int i = 0; i < bracketStructure.Count; i++)
            {
                expandedBrackets.Add(new Bracket(new[] { new Member(1, 1), new Member(bracketStructure[i][0], 0) }));
                for (int j = 0; j < bracketStructure[i].Count - 1; j++)
                {
                    Bracket b = new Bracket(new[] { new Member(1, 1), new Member(bracketStructure[i][j + 1], 0) });
                    expandedBrackets[i] = expandedBrackets[i].MultiplyWith(b);
                }
            }
            return expandedBrackets;
        }
        public ProtobufMessage ToPolyMessage(int index)
        {
            ProtobufMessage pm = new ProtobufMessage {
                UnivariatePolynomial = new UnivariatePolynomial
                {
                    Index = index,
                    SecretId = SecretId,
                    OwnerNodeId = OwnerNodeId,
                    
                }
            };
            foreach(BigInteger coefficients in coeffs)
            {
                
                pm.UnivariatePolynomial.Coefficients.Add(coefficients.ToString("X"));
            }
            return pm;
        }


    }
    public class Scalar
    {
        public BigInteger Value { get; set; }
        public int FromNodeId { get; set; }
        public int ToNodeId { get; set; }
        public int SecretId { get; set; }
        public Scalar(Networking.Messages.Scalar scalar)
        {
            this.Value = BigInteger.Parse(scalar.Value, System.Globalization.NumberStyles.HexNumber);
            this.FromNodeId = scalar.FromNodeId;
            this.ToNodeId = scalar.ToNodeId;
            this.SecretId = scalar.SecretId;

        }
        public Scalar(Networking.Messages.SecretShare share)
        {
            this.Value = BigInteger.Parse(share.Value, System.Globalization.NumberStyles.HexNumber);
            this.FromNodeId = share.FromNodeId;
            this.ToNodeId = share.ToNodeId;
            this.SecretId = share.SecretId;
        }
        public Scalar(BigInteger value, int fromNodeId, int toNodeId, int secretId)
        {
            Value = value;
            FromNodeId = fromNodeId;
            ToNodeId = toNodeId;
            SecretId = secretId;
        }

        public ProtobufMessage ToScalarMessage(int index)
        {
            return new ProtobufMessage
            {
                Scalar = new Networking.Messages.Scalar
                {
                    FromNodeId = PublicMemory.NodeId,
                    ToNodeId = ToNodeId,
                    SecretId = SecretId,
                    Index = (int)index,
                    Value = this.Value.ToString("X"),
                }
            };
            
        }
        public ProtobufMessage ToShareMessage(int index)
        {
            return new ProtobufMessage
            {
                SecretShare = new SecretShare
                {
                    FromNodeId = PublicMemory.NodeId,
                    ToNodeId = ToNodeId,
                    SecretId = SecretId,
                    Index = index,
                    Value = this.Value.ToString("X")
                }
            };
        }
    }

    public class SDParameters
    {
        public BigInteger p { get; set; }
        public int d { get; set; }
        public int k { get; set; }
    }
    public class Bracket
    {
        public List<Member> Members { get; set; } 
        public Bracket(List<Member> members)
        {
            this.Members = members;
        }
        public Bracket(Member[] members)
        {
            this.Members = new List<Member>(members);
        }
        public Bracket MultiplyWith(Bracket other)
        {
            List<Member> result = new List<Member>();
            for(int i = 0; i < Members.Count; i++)
            {
                for (int j = 0; j < other.Members.Count; j++)
                {
                    result.Add(new Member(Members[i].Value * other.Members[j].Value, Members[i].Degree + other.Members[j].Degree));
                }
            }
            for(int i = result.Count; i --> 0;)
            {
                for (int j = result.Count; j --> 0;)
                {
                    if(i != j && result[i].Degree == result[j].Degree)
                    {
                        result[i].Value += result[j].Value;
                        result.Remove(result[j]);
                    } 
                }
            }
            return new Bracket(result);
        }
    }
    public class Member
    {
        public BigInteger Value { get; set; }
        public BigInteger Degree { get; set; }
        public Member(BigInteger Value, BigInteger Degree)
        {
            this.Value = Value;
            this.Degree = Degree;
        }
    }
}
