#!/bin/bash

sed -i -e "s/<connectionString>/$1/g" appsettings.json
