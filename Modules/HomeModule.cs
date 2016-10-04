using Nancy;

namespace Epicodus
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
    }
  }
}



//For updateAll ***note from John***
// FORM ROUTE->
//
// FORM populated with Student Data:
// <input type="text" value="@Model.GetFName()"></input>
//
// POST ROUTE to SUCCESS PAGE->
// Student EditedStudent = new Student(Request.Form["fname"], )
