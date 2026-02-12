import Layout from "../../components/Layout";
import { useGetTasksQuery, useUpdateTaskStatusMutation } from "./taskApi";

const EmployeeTasks = () => {
  const { data, isLoading, error, refetch } = useGetTasksQuery();
  const [updateStatus, { isLoading: updating }] = useUpdateTaskStatusMutation();

  const handleStatusChange = async (id: string, currentStatus: number) => {
    // 1 = Todo, 2 = InProgress, 3 = Done
    const nextStatus = currentStatus === 1 ? 2 : currentStatus === 2 ? 3 : 3;

    await updateStatus({ id, status: nextStatus });
    refetch();
  };

  return (
    <Layout>
      <h2>My Tasks</h2>

      {isLoading && <p>Loading...</p>}
      {error && <p>Error loading tasks</p>}

      <div style={{ marginTop: "20px" }}>
        {data?.length === 0 && <p>No tasks assigned.</p>}

        {data?.map((task) => (
          <div
            key={task.id}
            style={{
              border: "1px solid #ccc",
              padding: "15px",
              marginBottom: "10px",
            }}
          >
            <h4>{task.title}</h4>
            <p>{task.description}</p>
            <p>Status: {task.status}</p>
            <p>Priority: {task.priority}</p>

            {task.status !== 3 && (
              <button
                onClick={() => handleStatusChange(task.id, task.status)}
                disabled={updating}
              >
                {task.status === 1 ? "Start Task" : "Mark as Done"}
              </button>
            )}
          </div>
        ))}
      </div>
    </Layout>
  );
};

export default EmployeeTasks;
