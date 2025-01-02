# GameNect- piattaforma social per i videogiocatori italiani

![Screenshot 2025-01-02 163839](https://github.com/user-attachments/assets/a634b617-6515-4805-95e4-e379072aad4f)

GameNect è una piattaforma dedicata ai videogiocatori italiani e pensata per offrire loro un unico luogo di discussione dove i membri della community potranno condividere dei loro contenuti, interagire con quelli degli altri utenti con la possibilità di commentare, mettere mi piace e seguirli. Il sito dà la possibilità di personalizzare il proprio profilo personale, partecipare a gruppi di discussione separati per genere di videogioco e pubblicare dei propri articoli destinati a tre categorie: news, recesioni e guide.

Questo progetto ha costituito il mio lavoro di tesi e per la sua realizzazione sono stati seguiti i principi dell'Interaction Design come la raccolta e definizione dei requisiti, con un'attenzione sull'analisi degli utenti a cui è rivolto il servizio tramite la raccolta di dati tramite un questionario. Oltre alla fase di ricerca sono stati trattati anche la realizzazione di un prototipo ad alta fedeltà e interattivo con conseguente sua valutazioni con utenti, per poi prosesguire con l'implementazione del sito ideato.

L'obiettivo finale è stato quello di realizzare un sito che vada a rispondere alle esigenze degli utenti alla quale è rivolto. Per la sua implementazione si è utilizzato il CMS WordPress che con i suoi plugin e temi ha permesso la realizzazione di un sito completo e funzionante con tutte le funzionalità pensate.

## Tecnologie
- WordPress con i suoi temi e plugin tra cui BuddyPress e Youzify

## Funzionalità
- **Registrazione e Accesso:** l'utente per poter visitare il sito deve creare un proprio account ed è quindi possibile registrarsi e in seguito fare l'accesso.
  
  ![image](https://github.com/user-attachments/assets/448f5bd5-b26c-405d-b4b6-43e0fcbe568a)
  
- **Homepage:** dalla pagina principale è possibile vedere le attività degli utenti iscritti con cui si può interagire e condividere i propri aggiornamenti.

  ![Screenshot 2025-01-02 163848](https://github.com/user-attachments/assets/51dfd4f5-eb3d-4da2-a83d-cef1fd05bcc5)

- **Profilo personale:** l'utente può visitare il suo profilo e quello degli altri dove si può mandare una richiesta di amicizia o un messaggio.

  ![Screenshot 2025-01-02 164318](https://github.com/user-attachments/assets/437f17d4-d921-4e00-9751-8ee5b030bc86)

- **Gruppo:** la pagina contiene gruppi di discussione suddivisi per genere di videogioco a cui si può partecipare e pubblicare al suo interno.
  
  ![Screenshot 2025-01-02 163902](https://github.com/user-attachments/assets/8d462820-aad7-4bff-9043-ac6f3102502a)
  ![Screenshot 2025-01-02 163924](https://github.com/user-attachments/assets/8e8fbb82-d6e6-4a20-b680-5e904a41bfcf)

  Pagina specifica del gruppo:
  
  ![Screenshot 2025-01-02 163958](https://github.com/user-attachments/assets/2ee6ab34-91fa-438c-8faf-6045e5c0ee5a)
  ![Screenshot 2025-01-02 164024](https://github.com/user-attachments/assets/663b202d-20e1-4fd3-a7e2-65c1b89ca514)

- **Guide, Recensioni e News:** le tre sezioni contengono articoli scritti dagli utenti stessi correlati al tema specifico quindi guida, recensione o notizia.

  ![Screenshot 2025-01-02 164037](https://github.com/user-attachments/assets/2e30ca1d-438b-49a1-86ef-73c1540907e2)

  Articolo specifico:
  ![Screenshot 2025-01-02 164105](https://github.com/user-attachments/assets/c1b5a72a-3d86-4e92-80d7-041a34bde48a)


- **Scrivere un articolo:** per scriverlo si compila un form dove si può inserire il titolo, descrizione, categoria, tag e immagine.

  ![Screenshot 2025-01-02 164134](https://github.com/user-attachments/assets/0c6ae7e5-5aa3-4284-87d3-37da6a81bf90)


## Installazione
Il sito è stato realizzato con WordPress installato in locale usando xampp ed esportato con il plugin duplicator.

1. **Prerequisiti**
    - Aver installato xampp
    
2. **Installazione**
    - Nella cartella del progetto in htdocs copiare il file installer.php
    - Creare il database su PHPMyAdmin con il nome del progetto
    - Sul browser andare sulla cartella del progetto su localhost e aprire il file installer.php
    - Seguire le istruzioni e inserire i dettagli del database
    - Avviare l'installazione
    - Infine accedere con il profilo admin per finire l'installazione
