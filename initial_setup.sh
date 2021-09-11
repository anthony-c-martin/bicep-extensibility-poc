#!/bin/bash

# This file contains the commands I ran to set GitHub Actions up for the first time

az login

az group create -n "BicepExtService" -l "East US 2"

rbacScope=$(az group show -n "BicepExtService" --query id -o tsv)
az ad sp create-for-rbac --name "BicepExtService GitHub CD" --role contributor --scopes $rbacScope --sdk-auth > credentials.json

# Now - copy + paste contents of credentials.json and add to this repo as a GitHub Secret with name AZURE_CREDENTIALS