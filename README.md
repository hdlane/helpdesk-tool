# Helpdesk Tool

## Description

Helpdesk Tool is a Windows WPF application built in C# that allows the user to view computer information and connect using the Microsoft Remote Assistance tool. It is intended to be used in conjunction with the [Helpdesk Service](https://github.com/hdlane/helpdesk-service) and [Helpdesk API](https://github.com/hdlane/helpdesk-api).

### Goal

The goal of Helpdesk Tool is to provide a helpdesk team a way to support their end users quickly. This is done by allowing them to see computer information at a glance and search for users / computers to connect.

### Background

In the past, I had used remote management tools to connect to Windows PCs and offer IT support. It was a quick and easy way for the helpdesk team to assist end users; however, there was usually a cost associated with them. So, I wanted to create my own application that was simple and open-source. This application sends a GET request to a specified endpoint that sends back JSON data with computer information. That data is then written to the application to be searched.

### Features

* Search by computer name / username / IP address
* Connect using Microsoft Remote Assistance (MSRA)
* Launch common tools for support

## Installation

### Requirements

* Windows 10 / 11
* .NET Framework 8
* dotnet CLI - Installed along with [.NET SDK](https://learn.microsoft.com/en-us/dotnet/core/install/windows)

## Usage

## License

[MIT](https://choosealicense.com/licenses/mit/)
