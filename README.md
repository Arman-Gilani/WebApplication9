# 🧩 WebApplication9 - ASP.NET MVC User Module with File Upload & RTC

**WebApplication9** is an ASP.NET MVC 5 project focused on demonstrating **CRUD operations** for the **User module** along with **image file upload functionality**. It adopts the MVC architecture, uses **Areas** for better modularity, and includes basic **HTTP** and **RTC (Real-Time Communication)** concepts for enhanced interaction.

---

## 🚀 Features

- ✅ CRUD operations for User 👤  
- 🖼️ Image/File upload functionality  
- 🗂️ Organized using **Areas** (Admin/User separation)  
- 🔗 Backend interaction using **HTTP**  
- 🔄 Basic **Real-Time Communication (RTC)** features  
- 🧱 Clean separation of:
  - **Controllers & Views**
  - **Models**
  - **BAL (Business Access Layer)**
  - **DAL (Data Access Layer)**
- ⚙️ Developed using Visual Studio

---

## 🛠️ Tech Stack

- 💻 ASP.NET MVC 5 / .NET Framework  
- 🌐 HTTP/RTC for communication  
- 💾 SQL Server / LocalDB  
- 🖼️ Razor View Engine  
- 🗃️ Entity Framework  
- ⚙️ Visual Studio IDE  

---

## 📁 Folder Structure

```
WebApplication9/
├── Areas/
│   ├── Admin/
│   │   ├── Controllers/
│   │   ├── Models/
│   │   └── Views/
│   └── User/
│       ├── Controllers/
│       ├── Models/
│       └── Views/
├── BAL/
├── DAL/
├── Controllers/
├── Models/
├── Views/
├── App_Start/
└── Web.config
```

---

## ⚙️ Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/Arman-Gilani/WebApplication9.git
   ```

2. Open the solution in **Visual Studio**.

3. Restore NuGet packages if needed.

4. Set up your **SQL Server / LocalDB** connection string in `Web.config`.

5. Build and run the project.

---

## 🙌 Contributing

Contributions are welcome! Feel free to fork the repository and submit pull requests to improve or add new features.

---

## 📄 License

This project is open-source and available under the [MIT License](LICENSE).
