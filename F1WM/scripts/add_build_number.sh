#!/bin/bash

DATE=`date +%Y%m%d%H%M`
echo "build number $DATE"
sed "s/<build_number>/$DATE/g" scripts/version.template.json > version.json
