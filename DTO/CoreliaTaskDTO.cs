﻿namespace CoreliaTask.DTO
{
    public class CoreliaTaskDTO
    {


        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public int UpdateTimes { get; set; }

    }
}
