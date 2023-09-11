using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Data;
using WebApp1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace WebApp1.Controllers
{
  public class RoleController : Controller
  {
    RoleManager<IdentityRole> roleManager;

    public RoleController(RoleManager<IdentityRole> roleManager)
    {
      this.roleManager = roleManager;
    }

    [Authorize(Policy = "readpolicy")]
    public IActionResult Index()
    {
      var roles = roleManager.Roles.ToList();
      return View(roles);
    }

    [Authorize(Policy = "writepolicy")]
    public IActionResult Create()
    {
      return View(new IdentityRole());
    }

    [HttpPost]
    public async Task<IActionResult> Create(IdentityRole role)
    {
      await roleManager.CreateAsync(role);
      return RedirectToAction("Index");
    }
  }
}
