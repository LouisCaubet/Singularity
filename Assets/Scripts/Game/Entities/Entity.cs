using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Singularity.Game.Innovations;
using Singularity.Game.MarketingTechs;
using Singularity.Game.Products;

namespace Singularity.Game.Entities {

    public abstract class Entity {

        public Entity () {

            marketingTechs = new MarketingTechs(this);
            products = new Products();
            innovations = new Innovations(this);
            innovations.init();

        }

        // The Innovations already done by the entity
        public ArrayList innovations_done = new ArrayList();
        // The Innovation currently researched by the entity
        public Innovation innovation_current = null;

        // The MarketingTechs already done by the entity
        public ArrayList marketingtech_done = new ArrayList();
        // The MarketingTech currently researched by the entity
        public MarketingTech marketingtech_current = null;

        // The Knowledge mastered by the entity
        public ArrayList knowledgeMastered = new ArrayList();

        // The Available Projects
        public ArrayList availableToDevelopment = new ArrayList();
        // The current project
        public Product current_project = null;

        // The products available for sale
        public ArrayList availableToSale = new ArrayList();
        // The currently sold products
        public ArrayList soldProducts = new ArrayList();


        // Data
        public Innovations innovations;
        public MarketingTechs marketingTechs;
        public Products products;


        public class Innovations {

            // First Row
            public NeuralNetwork NEURAL_NETWORK;

            // Second Row
            public IOT IOT;
            public Algorithms ALGORITHMS;

            // Third Row
            public IotPro IOT_ENTERPRISE;
            public IotHome IOT_HOME;
            public AdvertisingAlgorithms ADVERTISING;
            public SearchEngine SEARCH_ENGINE;

            // Fourth Row
            public EmbSys EMBEDDED_SYSTEMS;
            public CloudComputing CLOUD_COMPUTING;
            public DataMining DATA_MINING;
            public SocialNetworks SOCIAL_NETWORKING;

            // Fifth Row
            public DataAnalysis DATA_ANALYSIS;
            public EmbTreatment EMBEDDED_TREATMENT;
            public DataCloudComputing DATA_CLOUD_COMPUTING;

            // Sixth Row
            public Datacenters DATACENTERS;

            public Innovations (Entity super) {

                NEURAL_NETWORK = new NeuralNetwork(super);
                IOT = new IOT(super);
                ALGORITHMS = new Algorithms(super);
                IOT_ENTERPRISE = new IotPro(super);
                IOT_HOME = new IotHome(super);
                ADVERTISING = new AdvertisingAlgorithms(super);
                SEARCH_ENGINE = new SearchEngine(super);
                EMBEDDED_SYSTEMS = new EmbSys(super);
                CLOUD_COMPUTING = new CloudComputing(super);
                DATA_MINING = new DataMining(super);
                SOCIAL_NETWORKING = new SocialNetworks(super);
                DATA_ANALYSIS = new DataAnalysis(super);
                EMBEDDED_TREATMENT = new EmbTreatment(super);
                DATA_CLOUD_COMPUTING = new DataCloudComputing(super);
                DATACENTERS = new Datacenters(super);

            }

            public void init () {
                NEURAL_NETWORK.init();
                IOT.init();
                ALGORITHMS.init();
                IOT_ENTERPRISE.init();
                IOT_HOME.init();
                ADVERTISING.init();
                SEARCH_ENGINE.init();
                EMBEDDED_SYSTEMS.init();
                CLOUD_COMPUTING.init();
                DATA_MINING.init();
                SOCIAL_NETWORKING.init();
                DATA_ANALYSIS.init();
                EMBEDDED_TREATMENT.init();
                DATA_CLOUD_COMPUTING.init();
            }


            public Innovation getByName(string name) {

                if (name == NEURAL_NETWORK.getName()) return NEURAL_NETWORK;
                if (name == IOT.getName()) return IOT;
                if (name == ALGORITHMS.getName()) return ALGORITHMS;
                if (name == IOT_ENTERPRISE.getName()) return IOT_ENTERPRISE;
                if (name == IOT_HOME.getName()) return IOT_HOME;
                if (name == ADVERTISING.getName()) return ADVERTISING;
                if (name == SEARCH_ENGINE.getName()) return SEARCH_ENGINE;
                if (name == EMBEDDED_SYSTEMS.getName()) return EMBEDDED_SYSTEMS;
                if (name == EMBEDDED_TREATMENT.getName()) return EMBEDDED_TREATMENT;
                if (name == CLOUD_COMPUTING.getName()) return CLOUD_COMPUTING;
                if (name == DATA_MINING.getName()) return DATA_MINING;
                if (name == SOCIAL_NETWORKING.getName()) return SOCIAL_NETWORKING;
                if (name == DATA_ANALYSIS.getName()) return DATA_ANALYSIS;
                if (name == DATA_CLOUD_COMPUTING.getName()) return DATA_CLOUD_COMPUTING;
                if (name == DATACENTERS.getName()) return DATACENTERS;

                throw new ArgumentException("No Innovation with name " + name);

            }


        }

        public class MarketingTechs {

            // Row 0 - Tutorial
            public PublishApps PUBLISH_APPS;

            // First Row
            public Ads ADVERTISING;
            public InAppPurchases IN_APP_PURCHASES;

            // Second Row
            public Teasing TEASING;
            public Benchmarking BENCHMARKING;

            // Third Row
            public Buzz BUZZ;
            public TargetedAds TARGETED_ADS;

            // Fourth Row
            public Upselling UPSELLING;
            public TrialVersions TRIAL_VERSIONS;

            public MarketingTechs (Entity super) {

                PUBLISH_APPS = new PublishApps(super);
                ADVERTISING = new Ads(super);
                IN_APP_PURCHASES = new InAppPurchases(super);
                TEASING = new Teasing(super);
                BENCHMARKING = new Benchmarking(super);
                BUZZ = new Buzz(super);
                TARGETED_ADS = new TargetedAds(super);
                UPSELLING = new Upselling(super);
                TRIAL_VERSIONS = new TrialVersions(super);

                PUBLISH_APPS.init();
                ADVERTISING.init();
                IN_APP_PURCHASES.init();
                TEASING.init();
                BENCHMARKING.init();
                BUZZ.init();
                TARGETED_ADS.init();
                UPSELLING.init();
                TRIAL_VERSIONS.init();

            }

            public MarketingTech getByName(string name) {

                if (name == PUBLISH_APPS.getName()) return PUBLISH_APPS;
                if (name == ADVERTISING.getName()) return ADVERTISING;
                if (name == IN_APP_PURCHASES.getName()) return IN_APP_PURCHASES;
                if (name == TEASING.getName()) return TEASING;
                if (name == BENCHMARKING.getName()) return BENCHMARKING;
                if (name == BUZZ.getName()) return BUZZ;
                if (name == TARGETED_ADS.getName()) return TARGETED_ADS;
                if (name == UPSELLING.getName()) return UPSELLING;
                if (name == TRIAL_VERSIONS.getName()) return TRIAL_VERSIONS;

                throw new ArgumentException("No Marketing Tech with name " + name);

            }

            public MarketingTech[] getByRow(int row) {

                if (row == 0) {
                    return new MarketingTech[] { PUBLISH_APPS };
                }
                if (row == 1) {
                    return new MarketingTech[] { ADVERTISING, IN_APP_PURCHASES };
                }
                if (row == 2) {
                    return new MarketingTech[] { TEASING, BENCHMARKING };
                }
                if (row == 3) {
                    return new MarketingTech[] { BUZZ, TARGETED_ADS };
                }
                if (row == 4) {
                    return new MarketingTech[] { UPSELLING, TRIAL_VERSIONS };
                }

                return null;

            }

        }

        public class Products {

            public FaceRecognitionApp APP_FACE_RECON = new FaceRecognitionApp();
            public CreateSearchEngine CREATE_SEARCH_ENGINE = new CreateSearchEngine();
            public AdvertisingService ADVERTISING_SERVICE = new AdvertisingService();

            // IOT - Enterprises
            public FrameworkIOT IOT_FRAMEWORK = new FrameworkIOT();
            public RequirementAnalysisIOT REQUIREMENT_ANALYSIS_IOT = new RequirementAnalysisIOT();
            public SmartDataSoftware SMART_DATA_SOFTWARE = new SmartDataSoftware();
            public M2MCommunicationSys M2M_COMMUNICATION_SYS = new M2MCommunicationSys();
            public SyncPositionSysIOT POSITION_SYS_IOT = new SyncPositionSysIOT();
            public ClientTracker CLIENT_TRACKING_IOT = new ClientTracker();

            // IOT - Home
            public SmartHomeApps SMART_HOME_APPS = new SmartHomeApps();
            public SmartKitchen SMART_KITCHEN = new SmartKitchen();
            public SmartHomeCinema SMART_HOME_CINEMA = new SmartHomeCinema();
            public ClientDataCollection CLIENT_DATA_COLLECTION = new ClientDataCollection();
            public SmartEnergySystem SMART_ENERGY_SYSTEM = new SmartEnergySystem();
            public CarAutopilotTechs CAR_AUTOPILOT_TECHS = new CarAutopilotTechs();

            public Product getByName(string name) {

                if (name == APP_FACE_RECON.getName()) return APP_FACE_RECON;
                if (name == CREATE_SEARCH_ENGINE.getName()) return CREATE_SEARCH_ENGINE;
                if (name == ADVERTISING_SERVICE.getName()) return ADVERTISING_SERVICE;
                if (name == IOT_FRAMEWORK.getName()) return IOT_FRAMEWORK;
                if (name == REQUIREMENT_ANALYSIS_IOT.getName()) return REQUIREMENT_ANALYSIS_IOT;
                if (name == SMART_DATA_SOFTWARE.getName()) return SMART_DATA_SOFTWARE;
                if (name == M2M_COMMUNICATION_SYS.getName()) return M2M_COMMUNICATION_SYS;
                if (name == POSITION_SYS_IOT.getName()) return POSITION_SYS_IOT;
                if (name == CLIENT_TRACKING_IOT.getName()) return CLIENT_TRACKING_IOT;
                if (name == SMART_HOME_APPS.getName()) return SMART_HOME_APPS;
                if (name == SMART_KITCHEN.getName()) return SMART_KITCHEN;
                if (name == SMART_HOME_CINEMA.getName()) return SMART_HOME_CINEMA;
                if (name == CLIENT_DATA_COLLECTION.getName()) return CLIENT_DATA_COLLECTION;
                if (name == SMART_ENERGY_SYSTEM.getName()) return SMART_ENERGY_SYSTEM;
                if (name == CAR_AUTOPILOT_TECHS.getName()) return CAR_AUTOPILOT_TECHS;

                throw new System.ArgumentException("No Product with name " + name);

            }

        }

    }

}
