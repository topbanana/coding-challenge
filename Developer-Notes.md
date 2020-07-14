#  Notes from the developer

There were challenges regarding this task. Primarily the uncertainty that inferred interfaces could be changed. Thus changes have been made to the tests but not the implementation.

My preferred choice would be to rearchitect the search-engine to return just matching shirts and get that fully under test. Then I would enrich the result with the counts. Otherwise we have the situation with similar matching-implementations in the tests and the implemenation classes. The counts depend on the results and so we could separate out that code.

My choices during this task was to primarily split out the existing tests to determine what exactly was broken. We had many different types of assertions in individual tests and breaking those out allowed for finding the issues sooner. Also I added AutoFixture to remove the coupling of the literal objects created in the tests to eliminate cases that worked without testing edge-cases. Also the performance tests do test the performance and correctness of bulk operations.

This was a really good test by the way. But I'd prefer to change the SearchEngine interface and break the calculations from the search-result.