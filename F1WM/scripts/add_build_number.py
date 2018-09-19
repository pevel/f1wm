#! /usr/bin/python

import datetime
import re

date = datetime.datetime.now().strftime("%Y%m%d%H%M")

with open("scripts/version.template.json", "r") as version:
    lines = version.readlines()
with open("version.json", "w") as version:
    for line in lines:
        version.write(re.sub(r'<build_number>', date, line))