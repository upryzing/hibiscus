using System;
using Terminal.Gui;

Application.Run<LoginWindow>();

System.Console.WriteLine($"Username: {((LoginWindow)Application.Top).usernameText.Text}");

Application.Shutdown();

public class LoginWindow : Window
{
	public TextField usernameText;

	public LoginWindow()
	{
		Title = "Upryzing Hibiscus";

		var usernameLabel = new Label()
		{
			Text = "Username:"
		};

		usernameText = new TextField("")
		{
			X = Pos.Right(usernameLabel) + 1,
			Width = Dim.Fill(),
		};

		var passwordLabel = new Label()
		{
			Text = "Password:",
			X = Pos.Left(usernameLabel),
			Y = Pos.Bottom(usernameLabel) + 1
		};

		var passwordText = new TextField("")
		{
			Secret = true,
			X = Pos.Left(usernameText),
			Y = Pos.Top(passwordLabel),
			Width = Dim.Fill(),
		};

		var btnLogin = new Button()
		{
			Text = "Login",
			Y = Pos.Bottom(passwordLabel) + 1,
			X = Pos.Center(),
			IsDefault = true,
		};

		btnLogin.Clicked += () =>
		{
			if (usernameText.Text == "admin" && passwordText.Text == "password")
			{
				MessageBox.Query("Logging In", "Login Successful", "OK");
				Application.RequestStop();
			}
			else
			{
				MessageBox.ErrorQuery("Logging In", "Incorrect username or password", "OK");
			}
		};

		Add(usernameLabel, usernameText, passwordLabel, passwordText, btnLogin);
	}
}
