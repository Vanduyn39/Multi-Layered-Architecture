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

