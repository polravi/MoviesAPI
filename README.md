# MoviesAPI
 

>Migration files are created for seeding the dummyy data in MoviesAPI.DB project.
  Please run "Update-database" using Package Manager console. 
  It will create the local db as well as feed it with seed data.

Test Project is not created.

## API Endpoints:
* #### GetMoviesByCriteria : 
  This endpoint takes the search criteria of YearOfRelease or Title or Genre OR all of it. 
  It also work with any combination of 
     * YearOfRelease and Title  
     * Title and Genre
     * YearOfRelease and Genre
     * Any one of the 3 criteria.
   ```
   Example:
   http://localhost:22496/api/Movies/GetMoviesByCriteria?yor=2016&title=Ju&genre=action
   ```

* #### GetTop5Movies :
  This endpoint gives top 5 movies based on average rating.
  ```
  Example
  http://localhost:22496/api/Movies/GetTop5Movies
  ```
* #### GetTop5MoviesByUserID
  ```
  UserID : is required as querystring parameter
  
  Example:
  http://localhost:22496/api/Movies/GetTop5MoviesByUserID?UserId=1
  ```
* #### Post /api/UserRatings
  Endpoint :
  ```
  HttpPost:
  http://localhost:22496/api/UserRatings
  ```
  Headers:
  ```
  Content-Type:application/json
  ```
  Body:
  ```
  {
	"UserID":6,
	"MovieID":5,
	"Rating":4
  }
  ```
