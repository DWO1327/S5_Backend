FROM debian:stable-slim 
COPY . .
RUN chmod +x /publish.sh 
ENTRYPOINT [ "/publish.sh" ]