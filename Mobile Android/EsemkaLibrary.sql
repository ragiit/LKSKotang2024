CREATE DATABASE EsemkaLibrary
GO
USE EsemkaLibrary
GO

CREATE TABLE Books (
    ID INT PRIMARY KEY IDENTITY,
    Title VARCHAR(100),
    Author VARCHAR(100),
    PublicationYear INT,
    ISBN VARCHAR(20),
	Cover VARCHAR(200)
);

CREATE TABLE BookCategories (
    ID INT PRIMARY KEY IDENTITY,
    CategoryName VARCHAR(50)
);

CREATE TABLE BookDetails (
    BookID INT,
    CategoryID INT,
    CONSTRAINT PK_BookDetail PRIMARY KEY (BookID, CategoryID),
    FOREIGN KEY (BookID) REFERENCES Books(ID),
    FOREIGN KEY (CategoryID) REFERENCES BookCategories(ID)
);

CREATE TABLE BookContent (
    ID INT PRIMARY KEY IDENTITY,
    BookID INT,
    Content VARCHAR(MAX),  
    FOREIGN KEY (BookID) REFERENCES Books(ID)
);

CREATE TABLE Users (
    ID INT PRIMARY KEY IDENTITY,
    Username VARCHAR(50),
    Password VARCHAR(100),
	FullName VARCHAR(200),
	DateOfBirth DATE,
	Signature VARCHAR(1000),
    JoinDate DATETIME2 DEFAULT CURRENT_TIMESTAMP NOT NULL, 
);
 
CREATE TABLE Bookmarks (
    ID INT PRIMARY KEY IDENTITY,
    UserID INT,
    BookID INT,
    BookmarkDate DATE,
    FOREIGN KEY (UserID) REFERENCES Users(ID),
    FOREIGN KEY (BookID) REFERENCES Books(ID)
);

CREATE TABLE BookLikes (
    ID INT PRIMARY KEY IDENTITY,
    UserID INT,
    BookID INT,
    LikeDate DATE,
    FOREIGN KEY (UserID) REFERENCES Users(ID),
    FOREIGN KEY (BookID) REFERENCES Books(ID)
);

-- Inserting book categories into the BookCategories table
INSERT INTO BookCategories (CategoryName) VALUES 
('Fiction'),
('Non-fiction'),
('Drama'),
('Romance'),
('Fantasy'),
('Science'),
('History'),
('Biography'),
('Education'),
('Art'),
('Sports');

-- Inserting data into the Books table
INSERT INTO Books (Title, Author, PublicationYear, ISBN, Cover) VALUES
('To Kill a Mockingbird', 'Harper Lee', 1960, '9780061120084', 'https://example.com/to_kill_a_mockingbird.jpg'),
('1984', 'George Orwell', 1949, '9780451524935', 'https://example.com/1984.jpg'),
('Pride and Prejudice', 'Jane Austen', 1813, '9780141439518', 'https://example.com/pride_and_prejudice.jpg'),
('The Great Gatsby', 'F. Scott Fitzgerald', 1925, '9780743273565', 'https://example.com/the_great_gatsby.jpg'),
('The Catcher in the Rye', 'J.D. Salinger', 1951, '9780316769488', 'https://example.com/the_catcher_in_the_rye.jpg'),
('To the Lighthouse', 'Virginia Woolf', 1927, '9780156907392', 'https://example.com/to_the_lighthouse.jpg'),
('Moby-Dick', 'Herman Melville', 1851, '9780142437247', 'https://example.com/moby_dick.jpg'),
('Frankenstein', 'Mary Shelley', 1818, '9780199537150', 'https://example.com/frankenstein.jpg'),
('The Picture of Dorian Gray', 'Oscar Wilde', 1890, '9780141439570', 'https://example.com/the_picture_of_dorian_gray.jpg');

-- Inserting data into the BookDetails table
INSERT INTO BookDetails (BookID, CategoryID) VALUES
(1, 1), -- To Kill a Mockingbird - Fiction
(2, 1), -- 1984 - Fiction
(3, 1), -- Pride and Prejudice - Fiction
(4, 1), -- The Great Gatsby - Fiction
(3, 10), -- Pride and Prejudice - Art
(4, 11), -- The Great Gatsby - Sports
(5, 1), -- The Catcher in the Rye - Fiction
(6, 1), -- To the Lighthouse - Fiction
(7, 1), -- Moby-Dick - Fiction
(8, 2), -- Frankenstein - Fiction
(9, 1), -- The Picture of Dorian Gray - Fiction
(6, 10), -- To the Lighthouse - Art
(7, 11), -- Moby-Dick - Sports
(8, 1), -- Frankenstein - Horror
(9, 2); -- The Picture of Dorian Gray - Drama
 


 -- Inserting data into the BookContent table
INSERT INTO BookContent (BookID, Content) VALUES
(1, 'To Kill a Mockingbird is a novel by Harper Lee published in 1960. It was immediately successful, winning the Pulitzer Prize, and has become a classic of modern American literature. The plot and characters are loosely based on Lee''s observations of her family, her neighbors and an event that occurred near her hometown of Monroeville, Alabama, in 1936, when she was 10 years old. The story is told by the six-year-old Jean Louise "Scout" Finch. The novel is renowned for its warmth and humor, despite dealing with serious issues such as racial inequality and rape. The narrator''s father, Atticus Finch, has served as a moral hero for many readers and as a model of integrity for lawyers. Historian J.C. Furnas has described To Kill a Mockingbird as "the most widely read book dealing with race in America, and its protagonist, Atticus Finch, the most enduring fictional image of racial heroism."'),
(1, 'The novel opens with Scout describing her family history and introducing the Finch family and their small town of Maycomb, Alabama. Scout, her brother Jem, and their friend Dill are intrigued by their reclusive neighbor Boo Radley and make it their mission to draw him out of his house. Meanwhile, their father Atticus, a lawyer, defends Tom Robinson, a black man falsely accused of raping a white woman. The trial exposes the deep-seated racism in Maycomb and leads to tragic consequences.'),
(2, '1984 is a dystopian social science fiction novel by English novelist George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell''s ninth and final book completed in his lifetime. Thematically, Nineteen Eighty-Four centres on the consequences of totalitarianism, mass surveillance, and repressive regimentation of persons and behaviours within society. Orwell, a democratic socialist, modelled the totalitarian regime in the novel after Stalinist Russia and Nazi Germany. More broadly, the novel examines the role of truth and facts within politics and the ways in which they can be manipulated. The story takes place in an imagined future, the year 1984, when much of the world has fallen victim to perpetual war, omnipresent government surveillance, historical negationism, and propaganda. Great Britain, known as Airstrip One, has become a province of a totalitarian superstate named Oceania that is ruled by the Party, who employ the Thought Police to persecute individuality and independent thinking. Big Brother, the leader of the Party, enjoys an intense cult of personality despite the fact that he may not even exist. The protagonist, Winston Smith, is a diligent and skillful rank-and-file worker and Outer Party member who secretly hates the Party and dreams of rebellion. He enters into a forbidden love affair with a colleague, Julia, and starts to become rebellious by keeping a diary of his secret thoughts. Winston''s desire to rebel is aroused by O Brien, a high-ranking Inner Party member who secretly opposes the Party, and believes Winston will be worth the risk to the Party if he can be cured of his disbelief in Party doctrine.'),
(2, 'As Winston and Julia''s relationship deepens, they become involved in a subversive group known as the Brotherhood, led by the elusive Emmanuel Goldstein. However, their clandestine activities are discovered by the Thought Police, and they are arrested and tortured until they betray each other. In the end, Winston betrays Julia and is brainwashed into loving Big Brother, symbolizing the complete destruction of his individuality and humanity.'),
(3, 'Pride and Prejudice is an 1813 romantic novel of manners written by Jane Austen. The novel follows the character development of Elizabeth Bennet, the dynamic protagonist of the book who learns about the repercussions of hasty judgments and comes to appreciate the difference between superficial goodness and actual goodness. Its humour lies in its honest depiction of manners, education, marriage, and money during the Regency era in Great Britain. Mr. Bennet of the Longbourn estate has five daughters, but his property is entailed, meaning that none of the girls can inherit it. His wife has no fortune, so it is imperative that at least one of the girls marry well to support the others on his death. The novel revolves around the importance of marrying for love, not simply for financial gain or social status, despite the communal pressure to make a good (i.e., wealthy) match.'),
(3, 'Elizabeth Bennet, the spirited and intelligent protagonist, is one of Austen''s most popular characters. As the novel progresses, she learns to set aside her prejudices and misconceptions, ultimately finding love and happiness with the proud and enigmatic Mr. Darcy. Their romance is marked by misunderstandings, social conventions, and personal growth, making Pride and Prejudice a timeless tale of love and self-discovery.'),
(4, 'The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald. Set in the Jazz Age on Long Island, the novel depicts narrator Nick Carraway''s interactions with mysterious millionaire Jay Gatsby and Gatsby''s obsession to reunite with his former lover, Daisy Buchanan. The novel is widely regarded as a cautionary tale about the American Dream. It explores themes of decadence, idealism, resistance to change, social upheaval, and excess, creating a portrait of the Roaring Twenties that has been described as a cautionary tale regarding the American Dream.'),
(4, 'Nick Carraway, a young man from Minnesota, moves to New York in the summer of 1922 to learn about the bond business. He rents a house in the West Egg district of Long Island, a wealthy but unfashionable area populated by the newly rich. Across the bay in the more fashionable East Egg district, Nick''s cousin Daisy Buchanan and her husband Tom live in a grand house. Nick quickly becomes drawn into the glamorous and hedonistic world of his wealthy neighbors, including the enigmatic Jay Gatsby, whose extravagant parties are the talk of the town.'),
(5, 'Holden Caulfield is a cynical teenager who has been expelled from several schools. After failing out of yet another prep school, he wanders the streets of New York City feeling increasingly isolated and disillusioned with the "phoniness" of the adult world. He struggles with the loss of his brother Allie and his own mental health issues as he searches for authenticity in a world he perceives as superficial.'),
(5, 'Throughout his journey, Holden encounters various characters, including his younger sister Phoebe, a former teacher Mr. Antolini, and a prostitute named Sunny. Each interaction sheds light on different aspects of Holden''s personality and worldview.'),
(6, 'To the Lighthouse is a novel that centers on the Ramsay family and their visits to the Isle of Skye in Scotland between 1910 and 1920. The novel explores themes of love, marriage, creativity, and the passage of time. It is divided into three parts: "The Window," "Time Passes," and "The Lighthouse."'),
(6, 'In "The Window," the Ramsay family and their guests spend the summer at their vacation home on the Isle of Skye. Mrs. Ramsay, the matriarch of the family, organizes a trip to the lighthouse, but the journey is postponed due to bad weather. During this time, the characters reflect on their relationships and aspirations.'),
(7, 'Moby-Dick is a novel by Herman Melville that tells the story of Captain Ahab''s quest for revenge on the white whale Moby Dick, which had previously destroyed his ship and severed his leg at the knee. The novel is famous for its extensive descriptions of whaling and maritime life, as well as its philosophical reflections on fate, obsession, and the nature of evil.'),
(7, 'The narrative follows Ishmael, a sailor on Ahab''s ship, the Pequod, as he recounts his experiences and observations during the voyage. As the crew hunts the elusive whale across the oceans, tensions rise and conflicts emerge among the diverse group of characters onboard.'),
(8, 'Frankenstein; or, The Modern Prometheus is a novel written by English author Mary Shelley that tells the story of Victor Frankenstein, a young scientist who creates a sapient creature in an unorthodox scientific experiment. The creature, often mistakenly referred to as "Frankenstein," is abandoned by his creator and left to fend for himself in a hostile world.'),
(8, 'The novel explores themes of ambition, responsibility, and the consequences of scientific discovery. Victor Frankenstein becomes consumed by guilt and remorse as he witnesses the havoc wreaked by his creation, while the creature grapples with his own identity and seeks acceptance from society.'),
(9, 'The Picture of Dorian Gray is a Gothic and philosophical novel by Oscar Wilde, first published complete in the July 1890 issue of Lippincott''s Monthly Magazine. The novel tells the story of Dorian Gray, a young man who becomes obsessed with his own youth and beauty and makes a Faustian bargain to retain his youth while his portrait ages instead.'),
(9, 'As Dorian indulges in a life of hedonism and vice, his portrait becomes a reflection of his moral decay, while he remains perpetually youthful and unblemished. The novel explores themes of vanity, morality, and the pursuit of pleasure, and serves as a critique of the superficiality and decadence of Victorian society.');

 
-- Inserting data into the Users table with usernames as lowercase concatenation of full names
INSERT INTO Users (Username, Password, FullName, DateOfBirth, Signature)
VALUES
('johndoe', 'password1', 'John Doe', '1990-05-15', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.'),
('janesmith', 'password2', 'Jane Smith', '1985-09-23', 'Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.'),
('michaeljohnson', 'password3', 'Michael Johnson', '1993-02-10', 'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.'),
('emilybrown', 'password4', 'Emily Brown', '1988-07-30', 'Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
('davidwilson', 'password5', 'David Wilson', '1995-11-18', 'Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium.'),
('sarahtaylor', 'password6', 'Sarah Taylor', '1983-04-27', 'Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia'),
('christophermartinez', 'password7', 'Christopher Martinez', '1992-08-08', 'Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit.'),
('jessicawhite', 'password8', 'Jessica White', '1987-12-12', 'Sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.'),
('danielanderson', 'password9', 'Daniel Anderson', '1991-03-25', 'Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam.'),
('mariagarcia', 'password10', 'Maria Garcia', '1986-06-06', 'At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint.');

-- Temporary table to hold UserIDs and BookIDs
CREATE TABLE #TempUsers (UserID INT)
CREATE TABLE #TempBooks (BookID INT)

-- Inserting UserIDs from 1 to 10
DECLARE @UserID INT = 1
WHILE @UserID <= 10
BEGIN
    INSERT INTO #TempUsers (UserID) VALUES (@UserID)
    SET @UserID = @UserID + 1
END

-- Inserting BookIDs from 1 to 9
DECLARE @BookID INT = 1
WHILE @BookID <= 9
BEGIN
    INSERT INTO #TempBooks (BookID) VALUES (@BookID)
    SET @BookID = @BookID + 1
END

-- Inserting random data into Bookmarks table
INSERT INTO Bookmarks (UserID, BookID, BookmarkDate)
SELECT TOP 50 
    tu.UserID,
    tb.BookID,
    DATEADD(day, -1 * CAST(RAND() * 365 * 5 AS INT), GETDATE()) AS BookmarkDate
FROM
    #TempUsers tu
CROSS JOIN
    #TempBooks tb
WHERE
    NOT EXISTS (
        SELECT 1
        FROM Bookmarks bm
        WHERE bm.UserID = tu.UserID AND bm.BookID = tb.BookID
    )
ORDER BY NEWID()  -- Randomize the insertion order

-- Inserting random data into BookLikes table
INSERT INTO BookLikes (UserID, BookID, LikeDate)
SELECT TOP 50 
    tu.UserID,
    tb.BookID,
    DATEADD(day, -1 * CAST(RAND() * 365 * 5 AS INT), GETDATE()) AS LikeDate
FROM
    #TempUsers tu
CROSS JOIN
    #TempBooks tb
WHERE
    NOT EXISTS (
        SELECT 1
        FROM BookLikes bl
        WHERE bl.UserID = tu.UserID AND bl.BookID = tb.BookID
    )
ORDER BY NEWID()  -- Randomize the insertion order

-- Ensure at least one user does not have bookmarks and likes for a particular book
DECLARE @RandomUserID INT
SELECT TOP 1 @RandomUserID = UserID
FROM #TempUsers
ORDER BY NEWID()

DECLARE @RandomBookID INT
SELECT TOP 1 @RandomBookID = BookID
FROM #TempBooks
ORDER BY NEWID()

DELETE FROM Bookmarks
WHERE UserID = @RandomUserID AND BookID = @RandomBookID

DELETE FROM BookLikes
WHERE UserID = @RandomUserID AND BookID = @RandomBookID

-- Dropping temporary tables
DROP TABLE #TempUsers
DROP TABLE #TempBooks
