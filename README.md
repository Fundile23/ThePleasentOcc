# 🏢 ThePleasentOcc - Premium Student Residence Management System

![License](https://img.shields.io/badge/license-MIT-blue)
![ASP.NET](https://img.shields.io/badge/ASP.NET-8.0-purple)
![SQL Server](https://img.shields.io/badge/SQL-Server-red)
![Azure](https://img.shields.io/badge/Azure-Deployed-success)

## 📋 Overview
ThePleasentOcc is a comprehensive student residence management system built with ASP.NET Core MVC. It allows students to view available rooms, check real-time availability, and book accommodations. The system features a modern blue/grey UI with partial occupancy tracking for double and triple rooms.

## ✨ Features

### 🔐 **Authentication System**
- Student login with email validation (8 digits @VarsityOcc.az.ca)
- Demo access for non-students (view-only)
- Session-based authentication

### 🏠 **Residence Management**
- Four distinct residences: The Single, The Double, The Triple, The Mix
- Real-time bed availability tracking
- Partial occupancy for multi-bed rooms
- Detailed room information with pricing

### 📸 **Gallery System**
- Dynamic gallery images per residence
- Fallback to Unsplash images
- Responsive image grid

### 📊 **Statistics Dashboard**
- Total beds count
- Available beds
- Occupied beds
- Floor distribution

## 🛠️ Tech Stack

- **Backend**: ASP.NET Core MVC 8.0
- **Database**: SQL Server (Azure SQL)
- **ORM**: Entity Framework Core
- **Frontend**: Bootstrap 5, Font Awesome 6
- **Animations**: AOS (Animate on Scroll)
- **Authentication**: Session-based
- **Hosting**: Microsoft Azure

## 🚀 Live Demo

Visit the live site: [https://thepleasantocc.azurewebsites.net](https://thepleasantocc.azurewebsites.net)

## 📸 Screenshots

| Login Page | Residence Details |
|------------|-------------------|
| ![Login]("NewFolder/Logibpage.jpg") | ![Details](NewFolder/Preview.jpg) |

## 🏗️ Database Schema

```sql
Tables:
- Rooms (Id, RoomNumber, Residence, RoomType, TotalBeds, OccupiedBeds, Floor, Price, Size)
- Bookings (Id, RoomId, BedNumber, StudentName, StudentEmail, StudentPhone, BookingDate, Status)