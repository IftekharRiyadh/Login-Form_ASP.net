using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LoginForm
{
    public class SaveDataOffline
    {// Save data to localStorage when there's no internet connection
        function saveDataOffline(data)
        {
            // Serialize the data to JSON and store it in localStorage
            localStorage.setItem('offlineData', JSON.stringify(data));

        }
        function isOnline()
        {
            return navigator.onLine;
        }

        function syncDataWithServer()
        {
            if (isOnline())
            {
                // Retrieve data from localStorage
                const offlineData = JSON.parse(localStorage.getItem('offlineData'));

                if (offlineData)
                {
                    // Send data to the server using AJAX or fetch
                    fetch('/api/sync', {
                    method: 'POST',
                headers:
                        {
                            'Content-Type': 'application/json',
                },
                body: JSON.stringify(offlineData),
            })
                .then(response => {
                     if (response.ok)
                     {
                         // Data successfully synchronized, you can clear it from local storage
                         localStorage.removeItem('offlineData');
                     }
                 })
                .catch(error => {
                    console.error('Error during data synchronization:', error);
                });
                }
            }
        }


    }
}
