import {
  useGetTasksQuery,
  useCreateTaskMutation,
  useDeleteTaskMutation,
} from "./taskApi";
import { useState } from "react";

const ManagerTasks = () => {
  const { data, refetch, isLoading } = useGetTasksQuery();
  const [createTask] = useCreateTaskMutation();
  const [deleteTask] = useDeleteTaskMutation();

  const [title, setTitle] = useState("");

  const handleCreate = async () => {
    await createTask({
      title,
      description: "Test task",
      priority: 1,
      dueDate: null,
      assignedToUserId: "E92E2951-A0E7-49EF-BC1E-79BC39FF7AF5",
    }).unwrap();

    setTitle("");
    refetch();
  };

  if (isLoading) return <p>Loading...</p>;

  return (
    <div>
      <h3>Manager Tasks</h3>

      <input
        placeholder="Task Title"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
      />
      <button onClick={handleCreate}>Create</button>

      <ul>
        {data?.map((task) => (
          <li key={task.id}>
            {task.title} - {task.status}
            <button onClick={() => deleteTask(task.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ManagerTasks;
