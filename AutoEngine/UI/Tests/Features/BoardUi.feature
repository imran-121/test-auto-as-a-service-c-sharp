@board_ui
Feature: BoardUi
	In order to test board user interface
	As a software developemnet engineer in test
	I want to execute some test cases

@web_ui @medium_priority @smoke @positive @web_hook
Scenario: user is able to create a board
	Given user is already logged into the system
		| userName            | password |
		| ximran786@gmail.com | imran123 |
	And user clicks on create new board on board page
	When enters the name "TestBoardUI_Scernerio1" in title
	And clicks to create board button
	Then new board should be created

@web_ui @high_priority @end_to_end @positive @web_hook
Scenario: user is able to delete a board after creation
	Given user is already logged into the system
		| userName            | password |
		| ximran786@gmail.com | imran123 |
	And user clicks on create new board on board page
	When enters the name "TestBoardUI_Scernerio2" in title
	And clicks to create board button
	And clicks to more option form menu box
	And clicks to close board
	And clicks to permanently Delte Board
	Then board should not be found
		| noBoardFoundText |
		| Board not found. |



@web_ui @high_priority @end_to_end @positive @web_hook
Scenario: user is able to add a list in the board
	Given user is already logged into the system
		| userName            | password |
		| ximran786@gmail.com | imran123 |
	And user clicks on create new board on board page
	When enters the name "TestBoardUI_Scernerio3" in title
	And clicks to create board button
	And inserts list name "TestList" in input list
	And clicks to add list button
	Then search the list name "TestList" on page and it should exist
	