# az login
# 329c27a4-4c18-4953-8963-951fd6571018
# 57182d09-7f87-4d00-bdec-99ce6ef65e03
$subscription = "57182d09-7f87-4d00-bdec-99ce6ef65e03"

az login --tenant $subscription

# debug
# Get-AzureRMLog -CorrelationId 8c03c7e1-d5cc-43bd-922d-316696652799 -DetailedOutput

# login 
# Connect-AzureRmAccount