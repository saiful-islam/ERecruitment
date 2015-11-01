function ExamModel(ApplicantID, JobID, ExamTypeID, ExamDate, Marks, IsRejected, IsExamCompleted, IsPassed) {
    this.ApplicantID = ApplicantID;
    this.JobID = JobID;
    this.ExamTypeID = ExamTypeID;
    this.ExamDate = ExamDate;
    this.Marks = Marks;
    this.IsRejected = IsRejected;
    this.IsExamCompleted = IsExamCompleted;
    this.IsPassed = IsPassed;
}