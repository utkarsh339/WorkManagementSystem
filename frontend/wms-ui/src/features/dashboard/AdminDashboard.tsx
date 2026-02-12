import { useGetAdminDashboardQuery } from "./dashboardApi";
import Header from "../../components/Header";

const AdminDashboard = () => {
  const { data, isLoading, error } = useGetAdminDashboardQuery();

  if (isLoading) return <h2>Loading...</h2>;
  if (error) return <h2>Error loading dashboard</h2>;

  return (
    <>
      <Header />
      <div style={{ padding: "40px" }}>
        <h2>Admin Dashboard</h2>

        <div style={{ marginTop: "20px" }}>
          <p>Total Users: {data?.totalUsers}</p>
          <p>Active Users: {data?.activeUsers}</p>
          <p>Total Tasks: {data?.totalTasks}</p>
          <p>Completed Tasks: {data?.completedTasks}</p>
        </div>
      </div>
    </>
  );
};

export default AdminDashboard;
