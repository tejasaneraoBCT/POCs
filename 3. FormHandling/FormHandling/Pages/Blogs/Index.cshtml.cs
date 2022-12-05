using FormHandling.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FormHandling.Pages.Blogs
{
    public class IndexModel : PageModel
    {

        public List<Blog> Blogs = new List<Blog>
        {
            new Blog
            {
                Id= 1,
                Title= "Why you should learn ASP.NET Core?",
                Description="ASP.NET is one of the most popular web-development framework. It is used for building web apps on .NET Platform. In 2016 a new version of .NET framework is introduced which is open-source and cross platform."
            },
            new Blog
            {
                Id= 1,
                Title= "System Design Netflix",
                Description="In this article, we are going to learn System Design Netflix. This article is going to lead to much brainstorming as we will see what happens behind the scenes, which makes Netflix what it is today."
            },
            new Blog
            {
                Id= 1,
                Title= "React JS: What and Why?",
                Description="React.js is the most popular front-end framework for Web applications. In this article, we will learn what React.js (or simply React or Reactjs) is and why we should use Reactjs."
            }
        };
        
        public void OnGet()
        {
        }
    }
}
