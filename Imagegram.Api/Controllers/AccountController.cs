﻿using Imagegram.Api.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Imagegram.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// The method creates new account in the system.
        /// </summary>
        /// <returns>Created account.</returns>
        /// <response code="201">Account was created.</response>
        /// <response code="400">Request has incorrect format.</response>         
        [AllowAnonymous]
        [HttpPost("accounts")]
        public async Task<ActionResult<AccountDto>> Create([FromBody] CreateAccountRequest request)
        {
            var response = await _mediator.Send(request);
            return Created($"accounts/{response.Id}", response);
        }

        /// <summary>
        /// The method deletes account in the system with all related posts, images and comments.
        /// </summary>
        /// <returns>Created account.</returns>
        /// <response code="200">Account was deleted.</response>
        /// <response code="401">Account unauthorized or doesn't exist.</response> 
        [HttpDelete("accounts/me")]
        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}
