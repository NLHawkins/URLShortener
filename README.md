# URL Shortener

### Goal

Create an MVC project allowing a user to bookmark a site obscuring the URL through a shortened link and allowing users the ability to view, share, and rate other user bookmarks. 

### Objectives

* Make use of Bootstrap and hand-written CSS to style the application
* Redirect users away from the site while tracking their site usage
* Use MVC's default authentication views, viewmodels, and controllers
* Learn to display certain features to some users but not to others

### Tools Used

* ASP.NET MVC
* Entity Framework
* SQL Server
* Razor
* Bootstrap

### Features

##### The Home Index serves a a landing page and allows a user (logged-in or anonymous) to view all publicly available bookmarks. Authentication is required to create a new or favorite an existing bookmark. The ability to like a page is only available to non-owner users who have not previously liked the page.
![](https://cdn.rawgit.com/NLHawkins/URLShortener/4fa7be82/URLShortener/Images/URLPort3.png)
##### Table views are used to quickly browse a specific users bookmarks.
![](https://rawgit.com/NLHawkins/URLShortener/master/URLPort2.png)
##### A custom route configuration is used to meter link-use as well as to redirect user to the actual URL. 
```csharp
[Route("b/{hashlink}")]
public ActionResult Details(string hashlink, bool? dropClick)
{
	BookMark bookMark = db.BookMark.Where(h => h.HashLink == hashlink).FirstOrDefault();

	...

	ClickLog click = new ClickLog();
	click.BookMarkId = bookMark.Id;
	click.TimeLog = DateTime.Now;
	db.ClickLog.Add(click);
	db.SaveChanges();
	return Redirect($"http://{bookMark.URL}");
}
```
##### This project was built during Week 6 of the immersive back-end engineering course at The Iron Yard, Greenville, SC.

