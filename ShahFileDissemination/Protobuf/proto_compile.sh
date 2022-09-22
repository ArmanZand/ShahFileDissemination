#!/bin/bash

src_server_net_path=../SPServer/Networking/
src_client_net_path=../SPClient/Networking/

./protoc.exe -I=. --csharp_out=. *.proto --experimental_allow_proto3_optional


for cs_file in *.cs
do
    echo Copying $cs_file to $src_server_net_path$cs_file
    cp $cs_file $src_server_net_path$cs_file
    echo Copying $cs_file to $src_client_net_path$cs_file
    cp $cs_file $src_client_net_path$cs_file
done
read -p "Press Enter to end."