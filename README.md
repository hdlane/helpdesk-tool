# Helpdesk Tool

## Description

Helpdesk Tool is a Windows WPF application built in C# that allows the user to view computer information and connect using the Microsoft Remote Assistance tool. It is intended to be used in conjunction with the [Helpdesk Service](https://github.com/hdlane/helpdesk-service) and [Helpdesk API](https://github.com/hdlane/helpdesk-api).

### Goal

The goal of Helpdesk Tool is to provide a helpdesk team a way to support their end users quickly. This is done by allowing them to see computer information at a glance and search for users / computers to connect quickly.

### Background

While working in IT operations at one company, we had a remote management tool that we used to connect to Windows PCs. It was a quick and easy way for the helpdesk team to assist end users. I started at another company where paying for that kind of software wasn't an option, and neither was installing an open-source alternative. Instead, a batch script was used that had to be rerun every time the helpdesk needed to connect to a PC. They also needed to get the IP or hostname to type in, and if there were typos they would have to restart the process! 

Having seen the benefits of remote management software, I began working on spinning up my own solution. What started out as a Powershell GUI evolved into a WPF application that pulled information from a couple other systems to give the helpdesk team what they needed to assist end users quickly. Publishing this project on Github required that company-specific functionality be removed, but hopefully this allows the Helpdesk Tool to be adopted more easily.  

### Features

* Search by computer name / username / IP address
* Connect using Microsoft Remote Assistance (MSRA)
* Launch common tools for support

## Installation

### Requirements

## Usage

## License

[MIT](https://choosealicense.com/licenses/mit/)
