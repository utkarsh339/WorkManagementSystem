import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginPage from "../features/auth/LoginPage";
import ProtectedRoute from "../components/ProtectedRoute";
import AdminDashboard from "../features/dashboard/AdminDashboard";
import ManagerDashboard from "../features/dashboard/ManagerDashboard";
import EmployeeDashboard from "../features/dashboard/EmployeeDashboard";
import ManagerTasks from "../features/tasks/ManagerTasks";
import EmployeeTasks from "../features/tasks/EmployeeTasks";

const AppRoutes = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<LoginPage />} />

        <Route
          path="/admin"
          element={
            <ProtectedRoute role="Admin">
              <AdminDashboard />
            </ProtectedRoute>
          }
        />
        <Route
          path="/manager"
          element={
            <ProtectedRoute role="Manager">
              <ManagerDashboard />
            </ProtectedRoute>
          }
        />
        <Route
          path="/manager/tasks"
          element={
            <ProtectedRoute role="Manager">
              <ManagerTasks />
            </ProtectedRoute>
          }
        />
        <Route
          path="/employee"
          element={
            <ProtectedRoute role="Employee">
              <EmployeeDashboard />
            </ProtectedRoute>
          }
        />
        <Route
          path="/admin/tasks"
          element={
            <ProtectedRoute role="Admin">
              <ManagerTasks />
            </ProtectedRoute>
          }
        />

        <Route
          path="/employee/tasks"
          element={
            <ProtectedRoute role="Employee">
              <EmployeeTasks />
            </ProtectedRoute>
          }
        />
      </Routes>
    </BrowserRouter>
  );
};

export default AppRoutes;
