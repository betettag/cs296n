
# ASP.net-CommunitySite
Lab1
compare Message.cs in models from both branches

added
**[StringLength(100, MinimumLength = 2)]
[Required(ErrorMessage = "Please enter your UserName/Name")]**
public string User { get; set; }
**[DataType(DataType.Text)]
[Range(5, 230, ErrorMessage = "Please something meaningful")]
[Required(ErrorMessage = "No message. if you dont put one then whats the point?")]**
public string Body { get; set; }
