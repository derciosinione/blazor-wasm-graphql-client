﻿namespace BlazorWASMClient.Application.Contracts.Request;

public class LoginRequest
{
	public required string Email { get; set; }
	public required string Password { get; set; }
}
