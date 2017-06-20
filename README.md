# Competing Consumers
Competing Consumers demo with mass transit and rabbitmq.

This code demo shows the pattern described here: http://www.enterpriseintegrationpatterns.com/ramblings/18_starbucks.html  

Run multiple Barista services at the same time to see the effects of distributing the workload.
Modify the concurrency of the barista service to emulate a barista being able to make multiple drinks at the same time.


# Requires:  
A machine running RabbitMQ (currently set to localhost)


# Please Note:  
The web.config and app.config files are mostly ignored by the code. This is because the values have been hard coded to make it more obvious in technical demonstrations.

