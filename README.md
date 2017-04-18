# URL Shortener

### Goal

To Create and MVC project allowing a user to bookmark a site and obscure the URL through a shortened link. Users will also have the ability to view, share, and rate other user bookmarks.

### Objectives

* Make use of Bootstrap and hand-written CSS to style the application
* Redirect users away from the site while tracking their site usage
* Use MVC's default authentication views, viewmodels, and controllers
* Learn to display certain features to some users but not to others


### Features
*The Home Index serves a a landing page and allows a user (logged-in or anonymous) to view all publicly available bookmarks. Authentication is required to create a new or favorite an existing bookmark.*

![](https://github.com/NLHawkins/ShopList/blob/master/ShopList/Uploads/URLPort1.png)

*Tables are used to quickly browse a specific users bookmarks.*

![](https://github.com/NLHawkins/ShopList/blob/master/ShopList/Uploads/URLPort2.png)

*A custom route configuration is used to meter link-use as well as to redirect user to the actual URL.* 

        [Route("b/{hashlink}")]
        public ActionResult Details(string hashlink, bool? dropClick)
        {
            ...
            return Redirect($"http://{bookMark.URL}");
        }




##### This project was built during Week 6 of the immersive back-end engineering course at The Iron Yard, Greenville, SC.







##### This project was built during Week 6 of the immersive back-end engineering course at The Iron Yard, Greenville, SC.

*007 RESTful API built by Brennen Rogers @ http://007api.co/*
