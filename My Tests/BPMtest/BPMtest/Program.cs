

//using BMP;
using AutoMapper;
using BpmOrg;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMtest
{

    class Program
    {
        //static TaskQueryServiceClient srv = new TaskQueryServiceClient("TaskQueryServicePort");
        //static credentialType bpmCredential = new credentialType();
        //static taskListRequestType request = new taskListRequestType();
        //static workflowContextType contextType = new workflowContextType();
        //static task taskDetails = new task();
        static void Main(string[] args)
        {
            Test1();
        }

        private static void Test1()
        {

            Mapper.Initialize(cfg => {
                cfg.CreateMap<BpmOrg.workflowContextType, BpmOrg2.workflowContextType>();
                cfg.CreateMap<BpmOrg.credentialType, BpmOrg2.credentialType>();
                cfg.CreateMap<BpmOrg.task, BpmOrg2.task>();
                cfg.CreateMap<BpmOrg.processType, BpmOrg2.processType>();
                cfg.CreateMap<BpmOrg.systemAttributesType, BpmOrg2.systemAttributesType>();
                cfg.CreateMap<BpmOrg.identityType, BpmOrg2.identityType>();
                cfg.CreateMap<BpmOrg.hiddenAttributesType, BpmOrg2.hiddenAttributesType>();
                cfg.CreateMap<BpmOrg.systemMessageAttributesType, BpmOrg2.systemMessageAttributesType>();
                cfg.CreateMap<BpmOrg.callbackType, BpmOrg2.callbackType>();
                cfg.CreateMap<BpmOrg.scaType, BpmOrg2.scaType>();
                cfg.CreateMap<BpmOrg.EvidenceType, BpmOrg2.EvidenceType>();
                cfg.CreateMap<BpmOrg.customAttributesType, BpmOrg2.customAttributesType>();
                cfg.CreateMap<BpmOrg.actionType, BpmOrg2.actionType>();
                

            });


            TaskQueryServiceClient tqs = new TaskQueryServiceClient("TaskQueryServicePort");
            // provide credentials for ws-security authentication to WLS to call the web service
            tqs.ClientCredentials.UserName.UserName = "154315";
            tqs.ClientCredentials.UserName.Password = "welcome1";

            // set up the application level credentials that will be used to get a session on BPM (not WLS)
            credentialType cred = new credentialType();
            cred.login = "154315";
            cred.password = "welcome1";
            cred.identityContext = "jazn.com";

            // authenticate to BPM
            Console.WriteLine("Authenticating...");
            workflowContextType ctx = tqs.authenticate(cred);
            Console.WriteLine("Authenticated to TaskQueryService");

            taskListRequestType request = new taskListRequestType();
            request.workflowContext = ctx;
            // predicate
            taskPredicateQueryType pred = new taskPredicateQueryType();
            // predicate->order - e.g. ascending by column called "TITLE"
            orderingClauseType order = new orderingClauseType();
            order.sortOrder = sortOrderEnum.ASCENDING;
            order.nullFirst = false;
            order.Items = new string[] { "TITLE" };
            order.ItemsElementName = new ItemsChoiceType1[] { ItemsChoiceType1.column };
            orderingClauseType[] orders = new orderingClauseType[] { order };
            pred.ordering = orders;
            // predicate->paging controls - remember TQS.queryTasks only returns 200 maximum rows
            // you have to loop/page to get more than 200
            pred.startRow = "0";
            pred.endRow = "200";
            // predicate->task predicate
            taskPredicateType tpred = new taskPredicateType();
            // predicate->task predicate->assignment filter - e.g. "ALL" users
            tpred.assignmentFilter = assignmentFilterEnum.All;
            tpred.assignmentFilterSpecified = true;
            // predicate->task predicate->clause - e.g. column "STATE" equals "ASSIGNED"
            predicateClauseType[] clauses = new predicateClauseType[1];
            clauses[0] = new predicateClauseType();
            clauses[0].column = "STATE";
            clauses[0].@operator = predicateOperationEnum.EQ;
            clauses[0].Item = "ASSIGNED";
            tpred.Items = clauses;
            pred.predicate = tpred;
            // items->display columns
            displayColumnType columns = new displayColumnType();
            columns.displayColumn = new string[] { "TITLE" };
            // items->presentation id
            string presentationId = "";
            // items->optional info
            taskOptionalInfoType opt = new taskOptionalInfoType();
            object[] items = new object[] { columns, opt, presentationId };
            pred.Items = items;
            request.taskPredicateQuery = pred;

            // get the list of tasks
            Console.WriteLine("Getting task list...");
            task[] tasks = tqs.queryTasks(request);

            foreach (task task in tasks)
            {
                Console.WriteLine($"Task title {task.title}");
                Console.WriteLine($"Task state {task.systemAttributes.state}");
                Console.WriteLine($"Task taskId {task.systemAttributes.taskId}");
                Console.WriteLine($"Task taskNumber {task.systemAttributes.taskNumber}");
                Console.WriteLine("--------------------------------------------");
            }
            var myTask = tasks.ToList().Find(t => t.systemAttributes.taskId == "b8342a7a-4012-4f62-8da5-75b976f29929");
            //var myTask = tasks.First();
            var asd = myTask.systemAttributes;
            

            BpmOrg2.TaskServiceClient ts = new BpmOrg2.TaskServiceClient("TaskServicePort");
            //System.Xml.XmlNode[] payload = (System.Xml.XmlNode[])myTask.payload;
            //payload.ElementAt(0).ChildNodes.Item(1).InnerText = "changed in .net";
            myTask.payload = "asd";

            BpmOrg2.taskServiceContextTaskBaseType updateTaskRequest = new BpmOrg2.taskServiceContextTaskBaseType();
            updateTaskRequest.workflowContext = Mapper.Map<BpmOrg2.workflowContextType>(ctx);
            
            updateTaskRequest.task = Mapper.Map<BpmOrg2.task>(myTask);
            BpmOrg2.task updatedTask = ts.updateTask(updateTaskRequest);

            BpmOrg2.updateTaskOutcomeType updateTaskOutcomeRequest = new BpmOrg2.updateTaskOutcomeType();
            updateTaskOutcomeRequest.workflowContext = Mapper.Map<BpmOrg2.workflowContextType>(ctx);
            updateTaskOutcomeRequest.outcome = "OK";
            updateTaskOutcomeRequest.Item = updatedTask;
            ts.updateTaskOutcome(updateTaskOutcomeRequest);
        }

        private static void Test2()
        {
            //TaskQueryServiceClient tqs = new TaskQueryServiceClient("TaskQueryServicePort");

            //// provide credentials for ws-security authentication to WLS to call the web service
            //tqs.ClientCredentials.UserName.UserName = "154315";
            //tqs.ClientCredentials.UserName.Password = "welcome1";

            //// set up the application level credentials that will be used to get a session on BPM (not WLS)
            //credentialType cred = new credentialType();
            //cred.login = "154315";
            //cred.password = "welcome1";
            //cred.identityContext = "jazn.com";

            //// authenticate to BPM
            //Console.WriteLine("Authenticating...");
            //workflowContextType ctx = tqs.authenticate(cred);
            //Console.WriteLine("Authenticated to TaskQueryService");

            //taskDetailsByNumberRequestType request = new taskDetailsByNumberRequestType();
            //request.taskNumber = "201018";
            //request.workflowContext = ctx;
            //task task = tqs.getTaskDetailsByNumber(request);

            //TaskServiceClient ts = new TaskServiceClient("TaskServicePort");
            //System.Xml.XmlNode[] payload = (System.Xml.XmlNode[])task.payload;
            //payload.ElementAt(0).ChildNodes.Item(1).InnerText = "changed in .net";
            //task.payload = payload;

            //taskServiceContextTaskBaseType updateTaskRequest = new taskServiceContextTaskBaseType();
            //updateTaskRequest.workflowContext = ctx;
            //updateTaskRequest.task = task;
            //task updatedTask = ts.updateTask(updateTaskRequest);
        }
    }
}
