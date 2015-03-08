namespace LinkCondition.Load
{
    public static class AzureQueue
    {
        public static void sendToAzureStorageQueue(string JSONFeedNoMeta, string connectionString)
        {
            
        }
        
        public static void sendToAzureServiceBusQueue(string JSONFeedNoMeta)
        {

        }

        public static string createStorageQueueConnectionString(string azureStorageAccessKey, string storageAccountName)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=" + storageAccountName +
                                      ";AccountKey=" + azureStorageAccessKey;
            return connectionString;
        }
    }
}
