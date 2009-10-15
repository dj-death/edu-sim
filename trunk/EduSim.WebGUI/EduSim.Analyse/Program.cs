using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using org.drools.dotnet.compiler;
using org.drools.dotnet.rule;
using EduSim.Analyse.DTO;
using EduSim.Analyse.BusinessLayer;
using System.Collections;

namespace EduSim.Analyse
{
    /**
     * Create the User
     * Create the Team
     * Associate the Users to the Team
     * Create a Game
     * Associate the team to the Game
     * */
    class Program
    {
        /****
         * GetCurrentRoundIdentifier
         * Calculate the Optimal Market Demand for this round (GetMarketDemand)
         * Calculate the supply, if supply is less then demand, purchase everything (GetSupply)
         * If supply is more then demand, choose the right product(s) as criteria below
         * 
         * Get the product with maximum customer awareness (GetCustomerAwareness)
         * Get Product information for each participante using ProductDataView, this contains, 
         *      a. ProductId
         *      b. Performance
         *      c. Size
         *      d. Reliability
         *      e. Cost
         *      f. Marketing Spend
         *      g. Sales Spend
         *      h. Customer satisfaction Index from past data
         * Get the R&D data and compare against the RoundCritera for Performance and Size
         * Get the max Reliability as per the GameCriteria
         * Get the minimum price as per the GameCriteria
         * Get the best product
         * */
        static void Main(string[] args)
        {
            Stream stream = new FileStream("./rules/EduSimRules.drl", FileMode.Open);
            PackageBuilder builder = new PackageBuilder();
            builder.AddPackageFromDrl(stream);
            Package pkg = builder.GetPackage();
            org.drools.dotnet.RuleBase ruleBase = org.drools.dotnet.RuleBaseFactory.NewRuleBase();
            ruleBase.AddPackage(pkg);
            org.drools.dotnet.WorkingMemory workingMemory = ruleBase.NewWorkingMemory();

            ResultsManager rm = new ResultsManager();

            rm.Init(workingMemory);

            workingMemory.assertObject(rm);
            ArrayList resultList = new ArrayList();
            workingMemory.assertObject(resultList );

            workingMemory.fireAllRules();

            rm.QuantityPurchased();
        }
    }
}
