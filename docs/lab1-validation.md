
# ASP.net-CommunitySite
Lab1
compare Message.cs in models from both branches

added:<br/>

****

**[StringLength(100, MinimumLength = 2)]<br/>
[Required(ErrorMessage = "Please enter your UserName/Name")]<br/>**
public string User { get; set; }<br/>
**[DataType(DataType.Text)]<br/>
[Range(5, 230, ErrorMessage = "Please something meaningful")]<br/>
[Required(ErrorMessage = "No message. if you dont put one then whats the point?")]**<br/>
public string Body { get; set; }



added validation in the controller, specifically in the contact post method:<br/>

****

```c#
        if (ModelState.IsValid)
        {
            
            if (guestComment.Author == null)
                guestComment.Author = userRepo.Users.Find(u => u.Guest == true);
            commentRepo.AddComment(guestComment);
            return RedirectToAction("Index", "Home",new { message = "Your message has been successfully sent" });
        }
        else
        {
            //there is a validation error
            return RedirectToAction("Contact");
        }
```
and a little bit in the index method to indicate a successful post

**ModelState.AddModelError("SucessfulPost", message);**

which shows a message in the view

**<p>@Html.ValidationMessage("SucessfulPost")</p>**





