using FilRougeCore.Models;

namespace FilRougeApi.Builders
{
    public class ActivityBuilder
    {
        private string name;

        public ActivityBuilder Name(string name)
        {
            this.name = name;
            return this;
        }

        public Activity Build()
        {
            Activity activity= new Activity();
            if (name != null) activity.Name= name;
            return activity;
        }
    }
}
