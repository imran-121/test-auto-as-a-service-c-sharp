@board_api
Feature: BoardApi
	In order to test board api
	As a software developemnet engineer in test
	I want to execute some test cases


	
@api @medium_priority @smoke @positive @api_hook
Scenario: verify board creation api is creating board successfully
	Given read root url,key and token from "\inputs\API\TestData\Global\getRootUrlKeyToken.json"
	And with below request path and method
		| requestPath   | requestMethod |
		| /1/boards/	|   post		|
	And set the new board name as "TestBoardAPI_ScenerioNo1"
	When request is triggred
	Then newly created board id should exists in response content

@api @high_priority @end_to_end @regression @positive @api_hook
Scenario: verify board upade api is updating board 
	Given read root url,key and token from "\inputs\API\TestData\Global\getRootUrlKeyToken.json"
	And with below request path and method
		| requestPath   | requestMethod |
		| /1/boards/	|   post		|
	And set the new board name as "TestBoardAPI"
	And request is triggred
	When with below request path and method
		| requestPath   | requestMethod |
		| /1/boards/	|   put			|
	And update board name as "UpdatedTestBoardAPI_ScenerioNo2"
	And request is triggred
	Then verify board name value from update request response	

@api @high_priority @end_to_end @regression @positive @api_hook
Scenario: verify board delete api is deleting a board
	Given read root url,key and token from "\inputs\API\TestData\Global\getRootUrlKeyToken.json"
	And with below request path and method
		| requestPath   | requestMethod |
		| /1/boards/	|   post		|
	And set the new board name as "DeletedTestBoardAPI_ScenerioNo3"
	And request is triggred
	When with below request path and method
		| requestPath   | requestMethod |
		| /1/boards/	|   delete		| 
	And append board id to requestpath
	And request is triggred
	Then board should be deleted

