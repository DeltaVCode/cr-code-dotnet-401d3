import * as React from 'react';
import { Button, StyleSheet } from 'react-native';

import EditScreenInfo from '../components/EditScreenInfo';
import { Text, View } from '../components/Themed';

export default function TabTwoScreen(props : any) {
  React.useEffect(() => {
    console.log('Two', props.route);
  });

  const name = props.route.params?.name;

  function goToOne(){
    props.navigation.navigate('TabOneScreen', { name: 'Keith' });
  }

  function navName(name : string) {
    return () => props.navigation.push('TabTwoScreen', { name });
  }

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Tab Two: {name}</Text>
      <View style={styles.separator} lightColor="#eee" darkColor="red" />
      <Button title="Go to One" onPress={goToOne} />
      <Button title="Keith" onPress={navName('Keith')} />
      <Button title="Craig" onPress={navName('Craig')} />
      <Button title="Stacey" onPress={navName('Stacey')} />
      <EditScreenInfo path="/screens/TabTwoScreen.tsx" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  },
  title: {
    fontSize: 20,
    fontWeight: 'bold',
  },
  separator: {
    marginVertical: 30,
    height: 10,
    width: '80%',
  },
});
