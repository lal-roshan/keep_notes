# keep_notes

KeepNote is an application that maintains the notes created by user in a relational database.

The application allows user to create notes, each providing details about it’s title, description, status and the category it belongs to

The application consists of three main componenets: User, Category, Note

A user can create multiple categories.
There can be many notes for a single category.

User model consists of UserId and UserName.
Category model consists of CategoryId, Desrcription and UserId which gets mapped to the User who created the category.
Note model consists of NoteId, Title, Description, Status (can have three values Pending, Completed, Ignore) and CategoryId which maps to the Category that the note belongs to.

There are repositories for each models for performing their respective Create, Read, Update and Delete functions.

Model           Repository
""""""""""""""""""""""""""""""""""""
User           UserTableOperations
Category       CategoryTableOperations
Note           NotesTableOperations

