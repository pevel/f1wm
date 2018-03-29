#!/bin/bash

DATE=`date +%Y%m%d%H%M`
sed "s/<build_number>/$DATE/g" scripts/version.template.json > version.json
