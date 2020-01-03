#!/bin/bash

user="root"
host="DropletIpAddress"
localSourcePath="EthCoffee.api/bin/Release/netcoreapp3.0/publish"
remoteDestPath="/var/ethiotrade"

echo
echo "Deploying to server ..."
echo

sftp $user@$host <<EOF
put -r ./$localSourcePath $remoteDestPath
exit
EOF

echo
echo "Deployment Complete"
echo