import clsx from 'clsx';
import Heading from '@theme/Heading';
import styles from './styles.module.css';

type FeatureItem = {
  title: string;
  Img: string;
  description: JSX.Element;
};

const FeatureList: FeatureItem[] = [
  {
    title: 'Explorative API',
    Img: 'img/feature_happy.jpeg',
    description: (
      <>
        Siren is designed to be an explorative API. It is easy to use and easy to
        understand. It is a great tool for beginners and experts alike.
      </>
    ),
  },
  {
    title: 'No more typos!',
    Img: 'img/feature_thumbsup.jpeg',
    description: (
      <>
        Experts find Siren reduces the number of typos in their mermaid graphs by 99.99%*!
        <br></br>
        <sup style={{fontSize: '0.75rem'}}>* This is a made-up statistic.</sup>
      </>
    ),
  },
  {
    title: 'Choose your poison!',
    Img: 'img/feature_wondering.jpeg',
    description: (
      <>
        Siren is available for F#, C#, Python and JavaScript (with added Types)!
      </>
    ),
  },
];

function Feature({title, Img, description}: FeatureItem) {
  return (
    <div className={clsx('col col--4')}>
      <div className="text--center">
        <img style={{maxHeight: "300px"}} src={Img} role="img" />
      </div>
      <div className="text--center padding-horiz--md">
        <Heading as="h3">{title}</Heading>
        <p>{description}</p>
      </div>
    </div>
  );
}

export default function HomepageFeatures(): JSX.Element {
  return (
    <section className={styles.features}>
      <div className="container">
        <div className="row">
          {FeatureList.map((props, idx) => (
            <Feature key={idx} {...props} />
          ))}
        </div>
      </div>
    </section>
  );
}
