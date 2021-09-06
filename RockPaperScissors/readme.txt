Rock-Paper-Scissors Game (test task)

Used .NET Core 2.2

Important Notes:

- The players (both computer and human) use hardcoded names for simplicity purpose
- The player class contains Show method which displays some info because in the future it could be extended and display some text picture, for example. So it's not a proper thing to move this functionality into the Main method or Game class.
- To simplify the work with the input/output I am using here Func/Action, because otherwise the app would be much more complex if I introduce the messaging, etc.
- The models and business logic are located in the same library because the project is too small to create additional projects for the models, etc.
- The tests test only reasonable, most important and public functionality related to the game
- If number of the rounds is less than 10 the Computer player uses random generator to generate the figure(shape), after that its decision is based on statistics of its opponent.
- I am using Singleton here to keep the statistics, however in the real app I would try to avoid using Singletons as it might effect on the GC. The better option could be Redis, for example.
The statistics is erased after the app finishes its work, so it's not saved on the hard drive.
