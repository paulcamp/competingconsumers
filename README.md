# Competing Consumers
Competing Consumers demo with mass transit and rabbitmq.

This code demo shows the pattern described here: http://www.enterpriseintegrationpatterns.com/ramblings/18_starbucks.html  


# Requires:  
A machine running RabbitMQ (currently set to localhost)

# Quick Start
Run in visual studio with multiple startup projects:  
-  MTConsoleCachier
-  MTConsoleBarista
-  MTCompetingConsumers 


Run additional Barista services at the same time to see the effects of distributing the workload.
Modify the concurrency of the barista service to emulate a barista being able to make multiple drinks at the same time.


