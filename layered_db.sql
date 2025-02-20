--create database layered_db
--use layered_db
CREATE TABLE Users ( 
  user_id INT PRIMARY KEY IDENTITY, 
  username VARCHAR(50) NOT NULL, 
  email VARCHAR(100) NOT NULL UNIQUE, 
  created_at DATETIME DEFAULT GETDATE() 
); 

CREATE TABLE MoviesSeries ( 
  movie_series_id INT PRIMARY KEY IDENTITY, 
  title VARCHAR(100) NOT NULL, 
  genre VARCHAR(50), 
  release_date DATE, 
  description TEXT 
); 


CREATE TABLE Tags ( 
  tag_id INT PRIMARY KEY IDENTITY, 
  tag_name VARCHAR(50) NOT NULL UNIQUE 
); 

CREATE TABLE MovieSeriesTags ( 
  movie_series_id INT NOT NULL, 
  tag_id INT NOT NULL, 
  PRIMARY KEY (movie_series_id, tag_id), 
  FOREIGN KEY (movie_series_id) REFERENCES MoviesSeries(movie_series_id) ON DELETE CASCADE, 
  FOREIGN KEY (tag_id) REFERENCES Tags(tag_id) ON DELETE CASCADE 
);

CREATE TABLE Reviews ( 
  review_id INT PRIMARY KEY IDENTITY, 
  user_id INT NOT NULL, 
  movie_series_id INT NOT NULL, 
  review_text TEXT, 
  review_date DATETIME DEFAULT GETDATE(), 
  FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE CASCADE, 
  FOREIGN KEY (movie_series_id) REFERENCES MoviesSeries(movie_series_id) ON DELETE CASCADE 
); 

CREATE TABLE Ratings ( 
  rating_id INT PRIMARY KEY IDENTITY, 
  user_id INT NOT NULL, 
  movie_series_id INT NOT NULL, 
  rating DECIMAL(3, 2) CHECK (rating >= 0 AND rating <= 10), 
  FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE CASCADE, 
  FOREIGN KEY (movie_series_id) REFERENCES MoviesSeries(movie_series_id) ON DELETE CASCADE 
); 

-- IMPORT DATA
-- Insert data into Users table
INSERT INTO Users (username, email) VALUES
('john_doe', 'john.doe@example.com'),
('jane_smith', 'jane.smith@example.com'),
('alice_wonder', 'alice.wonder@example.com'),
('bob_builder', 'bob.builder@example.com');

-- Insert data into MoviesSeries table
INSERT INTO MoviesSeries (title, genre, release_date, description) VALUES
('Inception', 'Sci-Fi', '2010-07-16', 'A thief enters the dreams of others to steal secrets.'),
('The Matrix', 'Sci-Fi', '1999-03-31', 'A hacker discovers the true nature of reality.'),
('Titanic', 'Romance', '1997-12-19', 'A love story aboard the ill-fated RMS Titanic.'),
('The Dark Knight', 'Action', '2008-07-18', 'Batman faces the Joker in Gotham City.');

-- Insert data into Tags table
INSERT INTO Tags (tag_name) VALUES
('Thriller'),
('Mind-bending'),
('Romance'),
('Action'),
('Classic');

-- Insert data into MovieSeriesTags table
INSERT INTO MovieSeriesTags (movie_series_id, tag_id) VALUES
(1, 1), -- Inception - Thriller
(1, 2), -- Inception - Mind-bending
(2, 2), -- The Matrix - Mind-bending
(3, 3), -- Titanic - Romance
(4, 4), -- The Dark Knight - Action
(4, 5); -- The Dark Knight - Classic

-- Insert data into Reviews table
INSERT INTO Reviews (user_id, movie_series_id, review_text) VALUES
(1, 1, 'Amazing concept and execution!'),
(2, 2, 'Mind-blowing sci-fi!'),
(3, 3, 'A heartbreaking love story.'),
(4, 4, 'Best Batman movie ever!');

-- Insert data into Ratings table
INSERT INTO Ratings (user_id, movie_series_id, rating) VALUES
(1, 1, 9.5),
(2, 2, 9.0),
(3, 3, 8.5),
(4, 4, 9.8);

-- PROCEDURES
CREATE PROCEDURE GetMovieReviews 
    @movie_series_id INT 
    AS 
    BEGIN 
        SELECT r.review_id, r.user_id, u.username, r.review_text, 
        r.review_date 
        FROM Reviews r 
        JOIN Users u ON r.user_id = u.user_id 
        WHERE r.movie_series_id = @movie_series_id 
        ORDER BY r.review_date DESC; 
END;
GO

CREATE PROCEDURE AddReview 
    @user_id INT, 
    @movie_series_id INT, 
    @review_text TEXT 
    AS 
    BEGIN 
        INSERT INTO Reviews (user_id, movie_series_id, review_text, 
        review_date) 
        VALUES (@user_id, @movie_series_id, @review_text, GETDATE()); 
END;
GO

CREATE PROCEDURE GetTopRatedMovies 
    @top_count INT 
    AS 
    BEGIN 
        SELECT ms.movie_series_id, ms.title, AVG(r.rating) AS avg_rating 
        FROM MoviesSeries ms 
        JOIN Ratings r ON ms.movie_series_id = r.movie_series_id 
        GROUP BY ms.movie_series_id, ms.title 
        ORDER BY avg_rating DESC 
        OFFSET 0 ROWS FETCH NEXT @top_count ROWS ONLY; 
END; 
GO

CREATE PROCEDURE GetMoviesByTag 
    @tag_name VARCHAR(50) 
    AS 
    BEGIN 
        SELECT ms.movie_series_id, ms.title, ms.genre, ms.release_date 
        FROM MoviesSeries ms 
        JOIN MovieSeriesTags mst ON ms.movie_series_id = mst.movie_series_id 
        JOIN Tags t ON mst.tag_id = t.tag_id 
        WHERE t.tag_name = @tag_name; 
END;
GO