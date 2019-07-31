[![Build Status](https://dev.azure.com/aphisiit/ML_Issue_Detection/_apis/build/status/aphisiit.ML_Issue_Detection?branchName=master)](https://dev.azure.com/aphisiit/ML_Issue_Detection/_build/latest?definitionId=6&branchName=master)

This is images for detect issue log. Build by dotNet Core Framework and ML .Net

Run command example

`docker -p 8080:8080 --name test_ml -d aphisiit/ml_issue:tagname`

BasePath (Context path) : /IssueML

URL (POST-GET) : http://x.x.x.x/IssueML/api/IssuePredict?str=${SOME_SENTENCE} 

version release

- 20190731.6 : Train model with new data, Accuracy 91.5%

- 1.0 : Train model with new data

- lastest : Initial the ML Issue
