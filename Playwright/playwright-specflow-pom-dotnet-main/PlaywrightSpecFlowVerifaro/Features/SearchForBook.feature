Feature: SearchForBook
	Search for book on Amazon UK homepage

Scenario: Search for book 'how they broke britain' on Amazon UK homepage
	Given the user is on the amazon homepage
	When the user searches for 'james o'brien how they broke britain'
	Then the search results show the book how they broke britain as the first result
