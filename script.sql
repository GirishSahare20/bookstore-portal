use BookDB;

select * from Books;
select * from  PurchaseDetails;

select * from  UserInfoes;

--{"Name":"Book1","ISBN":"","Author":"","Description":""}

INSERT INTO books(BookID ,Name ,ISBN ,Author, Description ,Photo,Price ,Stock )
VALUES (1, 'Book1', '0143105422', 'TestAuthor1', 'English', 'image.jpg',100,100);
INSERT INTO books(BookID ,Name ,ISBN ,Author, Description ,Photo,Price ,Stock )
VALUES (2, 'Book2', '0143105423', 'TestAuthor2', 'English', 'image.jpg',100,100);
INSERT INTO books(BookID ,Name ,ISBN ,Author, Description ,Photo,Price ,Stock )
VALUES (3, 'Book3', '0143105424', 'TestAuthor3', 'English', 'image.jpg',100,100);


INSERT INTO UserInfoes(Userid, Username, Email, Name, Password )
VALUES (1, 'User1',  'a@a.com', 'Test User1','TestPwd1');

INSERT INTO UserInfoes(Userid, Username, Email, Name, Password )
VALUES (2, 'User2',  'b@b.com', 'Test User2','TestPwd2');

