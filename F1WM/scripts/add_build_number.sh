#!/bin/bash
DATE=`date +%Y%m%d%H%M`
BRANCH_NAME=${BRANCH:-'local'}
echo "build number $DATE"
echo "branch $BRANCH_NAME"
cat ./scripts/version.template.json | sed "s/<build_number>/$DATE/g" | sed 's,<branch>,'$BRANCH_NAME',g' > ./version.json