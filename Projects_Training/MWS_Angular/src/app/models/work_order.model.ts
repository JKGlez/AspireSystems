export class WorkOrder{



  constructor(
    public Id_WorkOrder: number,
    public Client_WorkOrder: number,
    public Vehicle_WorkOrder: number,
    public StartDate_WorkOrder: string,
    public FinishDate_WorkOrder: string,
    public Observation_WorkOrder: string,
    public FinalCost_WorkOrder: number,
    public Status_WorkOrder: number,
  ){
  }

}
