import { useGetManagerDashboardQuery } from "./dashboardApi";
import Header from "../../components/Header";

const ManagerDashboard = () => {
  const { data, isLoading, error } = useGetManagerDashboardQuery();

  if (isLoading) return <h2>Loading...</h2>;
  if (error) return <h2>Error loading dashboard</h2>;

  return (
    <>
      <Header />
      <div style={{ padding: "40px" }}>
        <h2>Manager Dashboard</h2>

        <div style={{ marginTop: "20px" }}>
          <p>Tasks Created By Me: {data?.tasksCreatedByMe}</p>
          <p>Pending Tasks: {data?.pendingTasks}</p>
          <p>In Progress Tasks: {data?.inProgressTasks}</p>
          <p>Overdue Tasks: {data?.overdueTasks}</p>
        </div>
      </div>
    </>
  );
};

export default ManagerDashboard;
